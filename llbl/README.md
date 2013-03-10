Template Usage
=================================

Use the sample LLBLGen Pro project file: Northwind.Data.llblgenproj to learn how to use the templates.

# Setup

When you create a new LLBLGen Pro project, dump the two folders Tasks and Templates in the directory in which you 
create your project file.

In your project, under Project > Project Settings > General, set the following two options:
  - Additional tasks folder: .\Tasks
  - Additional templates folder: .\Templates
  
Other optional settings:
  - Under Conventions > Database First Development > Catalog Refresher
      - Reset field order based on target order at refresh: True
      
Have fun!
