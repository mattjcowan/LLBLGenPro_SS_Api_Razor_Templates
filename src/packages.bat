nuget update -self
mkdir packages
nuget install .\ServiceGeneric\packages.config -OutputDirectory .\packages
nuget install .\ServiceSpecific\packages.config -OutputDirectory .\packages
nuget install .\Hosts\ConsoleHost\packages.config -OutputDirectory .\packages