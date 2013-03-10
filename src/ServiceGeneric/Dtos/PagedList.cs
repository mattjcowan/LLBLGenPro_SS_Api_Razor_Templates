using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Northwind.Data.Dtos
{
	/// <summary>
	/// Container for extension methods designed to simplify the creation of instances of <see cref="PagedList{T}"/>.
	/// </summary>
	public static class PagedListExtensions
	{
		/// <summary>
		/// Creates a subset of this collection of objects that can be individually accessed by index and containing metadata about the collection of objects the subset was created from.
		/// </summary>
		/// <typeparam name="T">The type of object the collection should contain.</typeparam>
		/// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
		/// <param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param>
		/// <param name="pageSize">The maximum size of any individual subset.</param>
		/// <returns>A subset of this collection of objects that can be individually accessed by index and containing metadata about the collection of objects the subset was created from.</returns>
		/// <seealso cref="PagedList{T}"/>
		public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> superset, int pageNumber, int pageSize)
		{
			return new PagedList<T>(superset, pageNumber, pageSize);
		}

		/// <summary>
		/// Creates a subset of this collection of objects that can be individually accessed by index and containing metadata about the collection of objects the subset was created from.
		/// </summary>
		/// <typeparam name="T">The type of object the collection should contain.</typeparam>
		/// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
		/// <param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param>
		/// <param name="pageSize">The maximum size of any individual subset.</param>
		/// <returns>A subset of this collection of objects that can be individually accessed by index and containing metadata about the collection of objects the subset was created from.</returns>
		/// <seealso cref="PagedList{T}"/>
		public static IPagedList<T> ToPagedList<T>(this IQueryable<T> superset, int pageNumber, int pageSize)
		{
			return new PagedList<T>(superset, pageNumber, pageSize);
		}

		/// <summary>
		/// Splits a collection of objects into n pages with an (for example, if I have a list of 45 shoes and say 'shoes.Split(5)' I will now have 4 pages of 10 shoes and 1 page of 5 shoes.
		/// </summary>
		/// <typeparam name="T">The type of object the collection should contain.</typeparam>
		/// <param name="superset">The collection of objects to be divided into subsets.</param>
		/// <param name="numberOfPages">The number of pages this collection should be split into.</param>
		/// <returns>A subset of this collection of objects, split into n pages.</returns>
		public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> superset, int numberOfPages)
		{
			return superset
				.Select((item, index) => new { index, item })
				.GroupBy(x => x.index % numberOfPages)
				.Select(x => x.Select(y => y.item));
		}

		/// <summary>
		/// Splits a collection of objects into an unknown number of pages with n items per page (for example, if I have a list of 45 shoes and say 'shoes.Partition(10)' I will now have 4 pages of 10 shoes and 1 page of 5 shoes.
		/// </summary>
		/// <typeparam name="T">The type of object the collection should contain.</typeparam>
		/// <param name="superset">The collection of objects to be divided into subsets.</param>
		/// <param name="pageSize">The maximum number of items each page may contain.</param>
		/// <returns>A subset of this collection of objects, split into pages of maximum size n.</returns>
		public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> superset, int pageSize)
		{
			if (superset.Count() < pageSize)
				yield return superset;
			else
			{
				var numberOfPages = Math.Ceiling(superset.Count() / (double)pageSize);
				for (var i = 0; i < numberOfPages; i++)
					yield return superset.Skip(pageSize * i).Take(pageSize);				
			}
		}
	}
	
	/// <summary>
	/// Represents the paging details provided in the results of collection queries.
	/// </summary>
	[Serializable]
    public class PagingDetails
    {
        public PagingDetails(){}
        public PagingDetails(IPagedList result)
        {
            FirstItemOnPage = result.FirstItemOnPage;
            LastItemOnPage = result.LastItemOnPage;
            HasNextPage = result.HasNextPage;
            HasPreviousPage = result.HasPreviousPage;
            IsFirstPage = result.IsFirstPage;
            IsLastPage = result.IsLastPage;
            PageCount = result.PageCount;
            PageNumber = result.PageNumber;
            PageSize = result.PageSize;
            TotalCount = result.TotalItemCount;
        }

        public int FirstItemOnPage { get; set; }
        public int LastItemOnPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
	
	/// <summary>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </summary>
	/// <remarks>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </remarks>
	/// <typeparam name="T">The type of object the collection should contain.</typeparam>
	/// <seealso cref="IEnumerable{T}"/>
	public interface IPagedList<out T> : IPagedList, IEnumerable<T>
	{
		///<summary>
		/// Gets the element at the specified index.
		///</summary>
		///<param name="index">The zero-based index of the element to get.</param>
		T this[int index] { get; }

		///<summary>
		/// Gets the number of elements contained on this page.
		///</summary>
		int Count { get; }

		///<summary>
		/// Gets a non-enumerable copy of this paged list.
		///</summary>
		///<returns>A non-enumerable copy of this paged list.</returns>
		IPagedList GetMetaData();
	}

	/// <summary>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </summary>
	/// <remarks>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </remarks>
	public interface IPagedList
	{
		/// <summary>
		/// Total number of subsets within the superset.
		/// </summary>
		/// <value>
		/// Total number of subsets within the superset.
		/// </value>
		int PageCount { get; }

		/// <summary>
		/// Total number of objects contained within the superset.
		/// </summary>
		/// <value>
		/// Total number of objects contained within the superset.
		/// </value>
		int TotalItemCount { get; }

		/// <summary>
		/// One-based index of this subset within the superset.
		/// </summary>
		/// <value>
		/// One-based index of this subset within the superset.
		/// </value>
		int PageNumber { get; }

		/// <summary>
		/// Maximum size any individual subset.
		/// </summary>
		/// <value>
		/// Maximum size any individual subset.
		/// </value>
		int PageSize { get; }

		/// <summary>
		/// Returns true if this is NOT the first subset within the superset.
		/// </summary>
		/// <value>
		/// Returns true if this is NOT the first subset within the superset.
		/// </value>
		bool HasPreviousPage { get; }

		/// <summary>
		/// Returns true if this is NOT the last subset within the superset.
		/// </summary>
		/// <value>
		/// Returns true if this is NOT the last subset within the superset.
		/// </value>
		bool HasNextPage { get; }

		/// <summary>
		/// Returns true if this is the first subset within the superset.
		/// </summary>
		/// <value>
		/// Returns true if this is the first subset within the superset.
		/// </value>
		bool IsFirstPage { get; }

		/// <summary>
		/// Returns true if this is the last subset within the superset.
		/// </summary>
		/// <value>
		/// Returns true if this is the last subset within the superset.
		/// </value>
		bool IsLastPage { get; }

		/// <summary>
		/// One-based index of the first item in the paged subset.
		/// </summary>
		/// <value>
		/// One-based index of the first item in the paged subset.
		/// </value>
		int FirstItemOnPage { get; }

		/// <summary>
		/// One-based index of the last item in the paged subset.
		/// </summary>
		/// <value>
		/// One-based index of the last item in the paged subset.
		/// </value>
		int LastItemOnPage { get; }
	}

	/// <summary>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </summary>
	/// <remarks>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </remarks>
	/// <typeparam name="T">The type of object the collection should contain.</typeparam>
	/// <seealso cref="IPagedList{T}"/>
	/// <seealso cref="BasePagedList{T}"/>
	/// <seealso cref="StaticPagedList{T}"/>
	/// <seealso cref="List{T}"/>
	public class PagedList<T> : BasePagedList<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PagedList{T}"/> class that divides the supplied superset into subsets the size of the supplied pageSize. The instance then only containes the objects contained in the subset specified by index.
		/// </summary>
		/// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
		/// <param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param>
		/// <param name="pageSize">The maximum size of any individual subset.</param>
		/// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
		public PagedList(IQueryable<T> superset, int pageNumber, int pageSize)
		{
			if (pageNumber < 1)
				throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
			if (pageSize < 1)
				throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");

			// set source to blank list if superset is null to prevent exceptions
			TotalItemCount = superset == null ? 0 : superset.Count();
			PageSize = pageSize;
			PageNumber = pageNumber;
			PageCount = TotalItemCount > 0
						? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
						: 0;
			HasPreviousPage = PageNumber > 1;
			HasNextPage = PageNumber < PageCount;
			IsFirstPage = PageNumber == 1;
			IsLastPage = PageNumber >= PageCount;
			FirstItemOnPage = (PageNumber - 1) * PageSize + 1;
			var numberOfLastItemOnPage = FirstItemOnPage + PageSize - 1;
			LastItemOnPage = numberOfLastItemOnPage > TotalItemCount
							? TotalItemCount
							: numberOfLastItemOnPage;

			// add items to internal list
			if (superset != null && TotalItemCount > 0)
				Subset.AddRange(pageNumber == 1
					? superset.Skip(0).Take(pageSize).ToList()
					: superset.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
				);
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="PagedList{T}"/> class that divides the supplied superset into subsets the size of the supplied pageSize. The instance then only containes the objects contained in the subset specified by index.
		/// </summary>
		/// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
		/// <param name="pageNumber">The one-based index of the subset of objects to be contained by this instance.</param>
		/// <param name="pageSize">The maximum size of any individual subset.</param>
		/// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
		public PagedList(IEnumerable<T> superset, int pageNumber, int pageSize)
			: this(superset.AsQueryable<T>(), pageNumber, pageSize)
		{
		}
	}
	
	///<summary>
	/// Non-enumerable version of the PagedList class.
	///</summary>
	public class PagedListMetaData : IPagedList
	{
		/// <summary>
		/// Protected constructor that allows for instantiation without passing in a separate list.
		/// </summary>
		protected PagedListMetaData()
		{
		}

		///<summary>
		/// Non-enumerable version of the PagedList class.
		///</summary>
		///<param name="pagedList">A PagedList (likely enumerable) to copy metadata from.</param>
		public PagedListMetaData(IPagedList pagedList)
		{
			PageCount = pagedList.PageCount;
			TotalItemCount = pagedList.TotalItemCount;
			PageNumber = pagedList.PageNumber;
			PageSize = pagedList.PageSize;
			HasPreviousPage = pagedList.HasPreviousPage;
			HasNextPage = pagedList.HasNextPage;
			IsFirstPage = pagedList.IsFirstPage;
			IsLastPage = pagedList.IsLastPage;
			FirstItemOnPage = pagedList.FirstItemOnPage;
			LastItemOnPage = pagedList.LastItemOnPage;
		}

		#region IPagedList Members

		/// <summary>
		/// 	Total number of subsets within the superset.
		/// </summary>
		/// <value>
		/// 	Total number of subsets within the superset.
		/// </value>
		public int PageCount { get; protected set; }

		/// <summary>
		/// 	Total number of objects contained within the superset.
		/// </summary>
		/// <value>
		/// 	Total number of objects contained within the superset.
		/// </value>
		public int TotalItemCount { get; protected set; }
		
		/// <summary>
		/// 	One-based index of this subset within the superset.
		/// </summary>
		/// <value>
		/// 	One-based index of this subset within the superset.
		/// </value>
		public int PageNumber { get; protected set; }

		/// <summary>
		/// 	Maximum size any individual subset.
		/// </summary>
		/// <value>
		/// 	Maximum size any individual subset.
		/// </value>
		public int PageSize { get; protected set; }

		/// <summary>
		/// 	Returns true if this is NOT the first subset within the superset.
		/// </summary>
		/// <value>
		/// 	Returns true if this is NOT the first subset within the superset.
		/// </value>
		public bool HasPreviousPage { get; protected set; }

		/// <summary>
		/// 	Returns true if this is NOT the last subset within the superset.
		/// </summary>
		/// <value>
		/// 	Returns true if this is NOT the last subset within the superset.
		/// </value>
		public bool HasNextPage { get; protected set; }

		/// <summary>
		/// 	Returns true if this is the first subset within the superset.
		/// </summary>
		/// <value>
		/// 	Returns true if this is the first subset within the superset.
		/// </value>
		public bool IsFirstPage { get; protected set; }

		/// <summary>
		/// 	Returns true if this is the last subset within the superset.
		/// </summary>
		/// <value>
		/// 	Returns true if this is the last subset within the superset.
		/// </value>
		public bool IsLastPage { get; protected set; }

		/// <summary>
		/// 	One-based index of the first item in the paged subset.
		/// </summary>
		/// <value>
		/// 	One-based index of the first item in the paged subset.
		/// </value>
		public int FirstItemOnPage { get; protected set; }

		/// <summary>
		/// 	One-based index of the last item in the paged subset.
		/// </summary>
		/// <value>
		/// 	One-based index of the last item in the paged subset.
		/// </value>
		public int LastItemOnPage { get; protected set; }

		#endregion
	}
	
	/// <summary>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </summary>
	/// <remarks>
	/// Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </remarks>
	/// <typeparam name="T">The type of object the collection should contain.</typeparam>
	/// <seealso cref="IPagedList{T}"/>
	/// <seealso cref="BasePagedList{T}"/>
	/// <seealso cref="PagedList{T}"/>
	/// <seealso cref="List{T}"/>
	public class StaticPagedList<T> : BasePagedList<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StaticPagedList{T}"/> class that contains the already divided subset and information about the size of the superset and the subset's position within it.
		/// </summary>
		/// <param name="subset">The single subset this collection should represent.</param>
		/// <param name="metaData">Supply the ".MetaData" property of an existing IPagedList instance to recreate it here (such as when creating a new instance of a PagedList after having used Automapper to convert its contents to a DTO.)</param>
		/// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
		public StaticPagedList(IEnumerable<T> subset, IPagedList metaData)
			: this(subset, metaData.PageNumber, metaData.PageSize, metaData.TotalItemCount)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StaticPagedList{T}"/> class that contains the already divided subset and information about the size of the superset and the subset's position within it.
		/// </summary>
		/// <param name="subset">The single subset this collection should represent.</param>
		/// <param name="pageNumber">The one-based index of the subset of objects contained by this instance.</param>
		/// <param name="pageSize">The maximum size of any individual subset.</param>
		/// <param name="totalItemCount">The size of the superset.</param>
		/// <exception cref="ArgumentOutOfRangeException">The specified index cannot be less than zero.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The specified page size cannot be less than one.</exception>
		public StaticPagedList(IEnumerable<T> subset, int pageNumber, int pageSize, int totalItemCount)
			: base(pageNumber, pageSize, totalItemCount)
		{
			Subset.AddRange(subset);
		}
	}

	/// <summary>
	/// 	Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </summary>
	/// <remarks>
	/// 	Represents a subset of a collection of objects that can be individually accessed by index and containing metadata about the superset collection of objects this subset was created from.
	/// </remarks>
	/// <typeparam name = "T">The type of object the collection should contain.</typeparam>
	/// <seealso cref = "IPagedList{T}" />
	/// <seealso cref = "List{T}" />
	public abstract class BasePagedList<T> : PagedListMetaData, IPagedList<T>
	{
		/// <summary>
		/// 	The subset of items contained only within this one page of the superset.
		/// </summary>
		public readonly List<T> Subset = new List<T>();

		/// <summary>
		/// Parameterless constructor.
		/// </summary>
		protected internal BasePagedList()
		{
		}

		/// <summary>
		/// 	Initializes a new instance of a type deriving from <see cref = "BasePagedList{T}" /> and sets properties needed to calculate position and size data on the subset and superset.
		/// </summary>
		/// <param name = "pageNumber">The one-based index of the subset of objects contained by this instance.</param>
		/// <param name = "pageSize">The maximum size of any individual subset.</param>
		/// <param name = "totalItemCount">The size of the superset.</param>
		protected internal BasePagedList(int pageNumber, int pageSize, int totalItemCount)
		{
			if (pageNumber < 1)
				throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
			if (pageSize < 1)
				throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");

			// set source to blank list if superset is null to prevent exceptions
			TotalItemCount = totalItemCount;
			PageSize = pageSize;
			PageNumber = pageNumber;
			PageCount = TotalItemCount > 0
			            	? (int) Math.Ceiling(TotalItemCount/(double) PageSize)
			            	: 0;
			HasPreviousPage = PageNumber > 1;
			HasNextPage = PageNumber < PageCount;
			IsFirstPage = PageNumber == 1;
			IsLastPage = PageNumber >= PageCount;
			FirstItemOnPage = (PageNumber - 1) * PageSize + 1;
			var numberOfLastItemOnPage = FirstItemOnPage + PageSize - 1;
			LastItemOnPage = numberOfLastItemOnPage > TotalItemCount
			                 	? TotalItemCount
			                 	: numberOfLastItemOnPage;
		}

		#region IPagedList<T> Members

		/// <summary>
		/// 	Returns an enumerator that iterates through the BasePagedList&lt;T&gt;.
		/// </summary>
		/// <returns>A BasePagedList&lt;T&gt;.Enumerator for the BasePagedList&lt;T&gt;.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return Subset.GetEnumerator();
		}

		/// <summary>
		/// 	Returns an enumerator that iterates through the BasePagedList&lt;T&gt;.
		/// </summary>
		/// <returns>A BasePagedList&lt;T&gt;.Enumerator for the BasePagedList&lt;T&gt;.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		///<summary>
		///	Gets the element at the specified index.
		///</summary>
		///<param name = "index">The zero-based index of the element to get.</param>
		public T this[int index]
		{
			get { return Subset[index]; }
		}

		/// <summary>
		/// 	Gets the number of elements contained on this page.
		/// </summary>
		public int Count
		{
			get { return Subset.Count; }
		}

		///<summary>
		/// Gets a non-enumerable copy of this paged list.
		///</summary>
		///<returns>A non-enumerable copy of this paged list.</returns>
		public IPagedList GetMetaData()
		{
			return new PagedListMetaData(this);
		}

		#endregion
	}	
}
