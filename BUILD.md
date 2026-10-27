# Build information — not a reproducible release recipe

The source corresponds to the tested DLL; 22 files have an additional comment-only change notice, so the files are not byte-for-byte identical to the original build inputs. No rebuild has been performed from this copy. The previously successful build used Windows x64, .NET SDK 10.0.402, the Windows Desktop targeting pack, and the five matching host reference assemblies identified by SHA-256 in `DEPENDENCIES.txt`.

The project embeds WinRing0.sys and WinRing0x64.sys from `source/PmcReader/Interop/`, but these driver files are intentionally absent from this local source candidate. It also needs the matching CapFrameX reference DLLs. Consequently the source folder alone cannot be built as provided. The required exact driver hashes are recorded in `NOTICE.md`. Do not source or redistribute unverified replacements.

If the missing authorized inputs are separately obtained, the build command is:

```powershell
dotnet build source\CapFrameX.PmcReader.Plugin.csproj -c Release -p:Platform=x64 -p:CapFrameXReferenceDir="<matching reference directory>"
```

The reference directory requires CapFrameX.Contracts.dll, LibreHardwareMonitorLib.dll, Serilog.dll, System.Management.dll and System.Reactive.dll. The earlier independent-directory rebuild used the same PC and same SDK; it is not a clean-machine reproduction. Any output differing from the tested DLL hash needs separate testing.
