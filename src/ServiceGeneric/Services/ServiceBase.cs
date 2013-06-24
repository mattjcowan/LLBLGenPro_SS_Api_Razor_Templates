using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.Text;
using Northwind.Data.Dtos;
using Northwind.Data.ServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services
{ 
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBaseAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                     
    [LogRequestFilter, LogExceptionFilter]
    public abstract partial class ServiceBase: Service
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBaseAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        public string BaseServiceUri
        {
            get { return base.Request.GetApplicationUrl().TrimEnd('/'); }
        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBaseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                                                                                                                             
    }
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                     
    public abstract partial class ServiceBase<TDto, TRepository>: ServiceBase
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                     
        where TDto: CommonDtoBase
        where TRepository: IEntityServiceRepository<TDto>
    {
        // Set using the IoC Container with Property Injection
        public virtual TRepository Repository { get; set; }

        // Retrieve files from request, save the files to the file system, and return the bytes of the files
        // PLEASE don't use this for very large files
        protected IList< byte[] > GetFilesInBytes()
        {
            var files = (base.RequestContext.Files ?? new IFile[0]);
            var filesInBytes = new List< byte[] >();
            foreach (var file in files)
            {
                if (string.IsNullOrEmpty(file.FileName))
                    continue;
                    
                byte[] fileData = null;

                var path = Path.Combine(Path.GetTempPath(), file.FileName);
                if (File.Exists(path)) File.Delete(path);
                file.SaveTo(path);

                var stream = new FileStream(path, FileMode.Open);
                fileData = new byte[stream.Length];
                stream.Read(fileData, 0, (int)stream.Length);
                stream.Close();
        
                filesInBytes.Add(fileData);
            }
            return filesInBytes;
        }

        protected IList< byte[] > GetFilesInBytesDirectApproach()
        {
            var files = (base.RequestContext.Files ?? new IFile[0]);
            var filesInBytes = new List< byte[] >();
            foreach (var file in files)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    var brl = file.ContentLength;
                    if (brl <= int.MaxValue)
                    {
                        fileData = binaryReader.ReadBytes(Convert.ToInt32(brl));
                    }
                    else
                    {
                        var b = new ArrayList();
                        while (binaryReader.BaseStream.Position < brl)
                        {
                            var readByte = binaryReader.ReadByte();
                            b.Add(readByte);
                        }
                        fileData = (byte[])b.ToArray(typeof(byte));
                    }
                }
                filesInBytes.Add(fileData);
            }
            return filesInBytes;
        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                                                                                                                             
    }

    public static class ServiceUtilExtensions
    {
        public static Image ToImage(this byte[] bytes)
        {
            Bitmap bitmap;
            try
            {
                using (var ms = new System.IO.MemoryStream(bytes, 0, bytes.Length))
                {
                    var image = System.Drawing.Image.FromStream(ms);
                    bitmap = new Bitmap(image.Width, image.Height);
                    var graphics = Graphics.FromImage(bitmap);
                    graphics.Clear(Color.Transparent);
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.DrawImage(image, 0, 0);
                    graphics.Flush();
                }
            }
            catch // if not an image, render a transparent bitmap
            {
                try
                {
                    var imageHeader = bytes.Length >= 78 ? 78 : 0 /* NO IMAGE */;
                    using (var ms = new System.IO.MemoryStream(bytes, imageHeader, bytes.Length - imageHeader))
                    {
                        var image = System.Drawing.Image.FromStream(ms);
                        bitmap = new Bitmap(image.Width, image.Height);
                        var graphics = Graphics.FromImage(bitmap);
                        graphics.Clear(Color.Transparent);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        graphics.DrawImage(image, 0, 0);
                        graphics.Flush();
                    }
                }
                catch // if not an image, render a transparent bitmap
                {
                    //bitmap = new Bitmap(300, 300);
                    bitmap = new Bitmap(48, 32);
                    var graphics = Graphics.FromImage(bitmap);
                    graphics.Clear(Color.Gainsboro);
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    graphics.Flush();
                }
            }
            return bitmap;
        }

        public static string ToImageSrc(this byte[] bytes, int? height, int? width)
        {
            byte[] imageBytes;
            var iw = 0;
            var ih = 0;
            using (var stream = new System.IO.MemoryStream())
            {
                {
                    var image = bytes.ToImage();
                    iw = image.Width;
                    ih = image.Height;
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    imageBytes = stream.ToArray();
                }
            }
            var imageBase64 = Convert.ToBase64String(imageBytes);
            if (height.HasValue && width.HasValue && height.Value > 0 && width.Value > 0)
            {
                ih = height.Value;
                iw = width.Value;
            }
            else if (height.HasValue && height.Value > 0)
            {
                var factor = 1.00 * iw / ih;
                ih = height.Value;
                iw = Convert.ToInt32(Math.Ceiling(ih * factor));
            }
            else if (width.HasValue && width.Value > 0)
            {
                var factor = 1.00 * ih / iw;
                iw = width.Value;
                ih = Convert.ToInt32(Math.Ceiling(iw * factor));
            }
            var imageSrc = string.Format("data:image/png;base64,{0}", imageBase64);
            return string.Format("<img src=\"{0}\" alt=\"\" style=\"height:{1}px;width:{2}px;\" />", imageSrc, ih, iw);
        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcUtilExtensionsAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                                                                                                                             
    }

    public class LogRequestFilterAttribute : Attribute, IHasRequestFilter
    {
        public int Priority { get { return 1; } }

        //This property will be resolved by the IoC container
        public ServiceStack.CacheAccess.ICacheClient Cache { get; set; }

        public void RequestFilter(IHttpRequest req, IHttpResponse res, object requestDto)
        {
            var userAgent = req.UserAgent;

            var requestDtoType = requestDto.GetType();
            var log = LogManager.GetLogger(requestDtoType);

            if (log.IsDebugEnabled)
            {
                log.DebugFormat("UserAgent: {0}", userAgent);
                log.DebugFormat("{0}:\n{1}", requestDtoType.FullName, JsonSerializer.SerializeToString(requestDto, requestDtoType));
            }
        }

        public IHasRequestFilter Copy()
        {
            return (IHasRequestFilter)MemberwiseClone();
        }
    }

    public class LogExceptionFilterAttribute : Attribute, IHasResponseFilter
    {
        public int Priority { get { return 1; } }

        public void ResponseFilter(IHttpRequest req, IHttpResponse res, object responseDto)
        {
            if (res.StatusCode <= 400)
                return;

            var responseDtoType = responseDto.GetType();
            var log = LogManager.GetLogger(responseDtoType);

            if (log.IsDebugEnabled)
            {
                log.DebugFormat("{0}:\n{1}", responseDtoType.FullName, JsonSerializer.SerializeToString(responseDto, responseDtoType));
            }
        }

        public IHasResponseFilter Copy()
        {
            return (IHasResponseFilter)MemberwiseClone();
        }
    }    
}
