# nuget-side-by-side
Need to install two versions of the same assembly via nuget side by side in a .NET Core Solution ?

# Your Situation
You absolutely HAVE to utilize a nuget package with multiple versions at the same time and link them with a single assembly (side by side).  Perhaps its due to a WebApi that was designed incorrectly or not versioned correctly and this is the ClientSdk for that service.  This is almost never necessary, but, when it is, you are in a weird spot.  Nuget is designed to prevent DLL hell but in this situation you want to break the rules.

# Warning
If you use this technique you will be breaking the dependancies chain that is automatically managed by Nuget resolution and you will run into problems with dependancies specified in the side by side packages.  Specifically, you might have to include their dependancies as side by side just like them if they are incompatible.  If you are lucky you can just include those sub dependancies in the parent project and every thing will be okay.

# Steps:
1) Prerequisites: Isolate all code dependancies on problem assembly behind another proxy assembly.  
2) Make 2 of those proxy assemblies.  
3) Install the 2 different versions of your problem assembly in those 2 proxy assemblies.  
4) Mark your problem assemblies as private=All in package management.  
5) Give your problem assemblies descriptive Aliases in package to prevent confusion later on.  
6) Make your proxy assemblies build as exe's instead of DLL's by utilizing.  
7) Utilize your Package Alias via 'extern alias MyAlias;' and 'using MyAlias::Asm.Type'.  
8) Add post build step that copies problem assemblies from bin/debug up to a folder under the project.  
9) Add a post build step that deletes the problem assemblies from bin/debug.  
10) Mark those problem assemblies (which are transient) as CopyIfNewer in their folder.  
11) Add AppDomain.AssemblyResolve Event to the main program.  
12) 'Assembly.LoadFile(sting path)' the correct assemblies when requested by the runtime.  
13) Build a factory or other absractions to determine the version you need and when.  
14) Profit.  



