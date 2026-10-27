# CapFrameX-PMCReader

**Source and documentation only.** The tested plugin DLL has not been released and is not included in this repository. The WinRing0 BSD notice is supported by matching binaries and notices in the referenced upstream projects; original-package verification remains unavailable.

## CPU coverage and sensors

This unofficial plugin includes Clam PmcReader-derived AMD Zen 1–Zen 5 measurement implementations and plugin-side CPU vendor, family and model selection. Code paths do not guarantee operation on every Zen CPU. Intel measurement implementations and selection paths are also included, but this modified plugin has not been hardware-tested on Intel CPUs.

The tested environment is Ryzen 7 5700X / Windows x64 / CapFrameX 1.9.0.8. In that environment the four added sensors displayed and updated, and shutdown logging was observed. Numerical accuracy and other CPU/CapFrameX combinations remain unverified. The four added sensors are enabled by the plugin for AMD Family 19h / Model 21h, subject to the corresponding configurations being available:

- L3 Mem Latency (clocks)
- L3 Pend. Miss/C
- L2 Code Cache Hit Rate
- L2 Data Cache Hit Rate

The existing `CPU L3 Hit Rate` is a separate sensor with selection paths for multiple AMD and Intel architectures; it is not one of the four additions. The 5700X test log recorded its L3 monitoring configuration as enabled, but the reported four-sensor test did not independently establish L3 Hit Rate value updates.

Tested DLL SHA-256: `43FFD81D3FB32F251458F05EF977DABF39CDC8F06F3793B378956BE70A5FD0B9`.

Planned repository: https://github.com/childalabo/CapFrameX-PMCReader

## Installation and restoration

In an environment authorized for testing or distribution, fully exit CapFrameX, including its tray process. Back up the existing `CapFrameX.PmcReader.Plugin.dll` somewhere safe, then, if the separately distributed tested DLL becomes available, put it beside `CapFrameX.exe`. No DLL is provided in this repository. The tested configuration was launched as administrator. Avoid running other PMC tools, including Clam PmcReader, at the same time.

To restore, fully exit CapFrameX and replace the plugin DLL with the backup. If there was no original DLL, remove the added file. This does not guarantee unloading a shared WinRing0 device or restoring PMC state.

## Security and limitations

Microsoft classifies WinRing0 as a known vulnerable driver associated with CVE-2020-14979. Windows security features may block it. Do not disable security protections to use it.

PMC and HWCR state restoration and complete exclusion of other tools are not provided. L2, L3, and DRAM PMCs initialize regardless of individual sensor selection. Abnormal termination and coexistence with other PMC tools have not been validated.

## Source and licenses

`source/` corresponds to the source used to build the tested DLL; 22 files include a comment-only change notice added afterward, including three MPL-marked Interop files. Original license notices are retained. The driver files are omitted from the source folder, so this folder alone cannot build the DLL. See `BUILD.md`, `NOTICE.md`, and `licenses/`.

Newly created project code, including `CaptureLifetimeGate.cs`, is offered under MIT to the extent it contains no third-party code or rights, with `Copyright (c) 2026 childalabo`; see `NOTICE.md` and `licenses/LICENSE-New-Project-Code.txt`. Existing third-party notices and terms continue to apply.
