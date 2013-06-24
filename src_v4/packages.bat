nuget update -self
mkdir packages
nuget install .\ServiceGeneric\packages.config -OutputDirectory .\packages
nuget install .\ServiceSpecific\packages.config -OutputDirectory .\packages
nuget install .\Hosts\ConsoleHost\packages.config -OutputDirectory .\packages
nuget update .\ServiceGeneric\packages.config -Safe 
nuget update .\ServiceSpecific\packages.config -Safe
nuget update .\Hosts\ConsoleHost\packages.config -Safe