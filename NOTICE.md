# Third-party notices — review draft

This repository contains source and documentation; the plugin DLL has not been released. Preserve the license texts and file-level notices in `licenses/` and `source/`. The project uses multiple licenses; no single license below covers the entire folder.

## Clam PmcReader

The plugin compiles PmcReader-derived source from https://github.com/clamchowder/PmcReader, compared against commit `83e86bebc3a8a88d7baf697989ce06e204bfdfe8`. The upstream repository provides Apache License 2.0; see `licenses/LICENSE-PmcReader-Apache-2.0.txt`. Twenty-two files with confirmed textual differences against this baseline carry a change notice in this review copy; see `CHANGES.md`. Four files do not exist in that baseline; they also appear in the CapFrameX project. Existing third-party notices remain applicable.

## LibreHardwareMonitor

Six files under `source/PmcReader/Interop` identify LibreHardwareMonitor and contributors and MPL 2.0: AdvApi32.cs, Kernel32.cs, KernelDriver.cs, OpCode.cs, Ring0.cs and ThreadAffinity.cs. Their original file notices are retained. See `licenses/LICENSE-LibreHardwareMonitor.txt`. The corresponding source files are provided in this folder. The Release description must link recipients to the exact repository revision containing these files and the MPL license. Upstream: https://github.com/LibreHardwareMonitor/LibreHardwareMonitor.

## CapFrameX and integration

CapFrameX is distributed under MIT; its notice includes `Copyright (c) 2018-2026 DevTechProfile`. See `licenses/LICENSE-CapFrameX.txt` and https://github.com/CXWorld/CapFrameX. Some plugin integration files match the public CapFrameX tree. The project owner states that the project code was created or modified by ChatGPT Work at their direction and directs that newly created code, including `CaptureLifetimeGate.cs`, be offered under MIT to the extent it does not incorporate third-party code or rights; see `licenses/LICENSE-New-Project-Code.txt`. This direction does not establish the absence of third-party material or change the terms applicable to existing CapFrameX, Clam, LibreHardwareMonitor or other code. For newly created project code within that scope, the designated copyright notice is `Copyright (c) 2026 childalabo`.

## WinRing0

The DLL embeds WinRing0.sys (SHA-256 `206EE7A7C3F4D9496F742CCB84718F556ECB4BA2A95FE7E0CDF3A003FFBE4597`) and WinRing0x64.sys (`11BD2C9F9E2397C9A16E0990E4ED2CF0679498FE0FD418A3DFDAC60B5C160EE5`). The binaries match Clam commit `83e86bebc3a8a88d7baf697989ce06e204bfdfe8`. Open Hardware Monitor also contains the same Git blobs alongside an OpenLibSys.org BSD notice. See `licenses/LICENSE-WinRing0-DRAFT.txt` for copyright, conditions and disclaimer. The matching binaries and associated notices reasonably support applying this two-condition BSD notice to these binaries, provided its full copyright notice, conditions and disclaimer accompany binary distribution. The original distribution archive and any additional terms have not been directly verified; no evidence prohibiting redistribution was found in the reviewed materials. This assessment is limited to WinRing0 and does not resolve other components. WinPmem is not embedded.
