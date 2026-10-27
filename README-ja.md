# CapFrameX-PMCReader

**ソースと文書のみ。** 試験済みプラグイン DLL は未配布で、このリポジトリには含まれません。WinRing0 の BSD 通知は、参照先の同一バイナリと通知により適用を合理的に判断できますが、元の配布物との直接照合はできていません。

## CPU 対応範囲とセンサー

この非公式プラグインには、Clam PmcReader 由来の AMD Zen 1～Zen 5 向け計測実装と、CPU のメーカー・family・model を判別するプラグイン側の経路が含まれます。コードがあることは、すべての Zen CPU での動作を保証するものではありません。Intel 向け実装と判別経路も含みますが、今回の改造版では Intel CPU の実機検証はしていません。

実機確認済みの環境は Ryzen 7 5700X / Windows x64 / CapFrameX 1.9.0.8 です。以下の追加４センサーの表示・数値更新と終了処理ログを確認しました。数値の厳密な精度や、その他の CPU・CapFrameX の組み合わせは未検証です。追加４センサーは AMD Family 19h / Model 21h 向けで、対応する計測設定を取得できた場合に有効になります。

- L3 Mem Latency（clocks）
- L3 Pend. Miss/C
- L2 Code Cache Hit Rate
- L2 Data Cache Hit Rate

既存の `CPU L3 Hit Rate` は追加４項目とは別のセンサーで、複数の AMD・Intel アーキテクチャ向けの選択経路があります。5700X の試験ログでは L3 計測設定が有効でしたが、報告された４項目の試験では、既存の L3 Hit Rate の値更新を個別に確認していません。

対象 DLL の SHA-256: `43FFD81D3FB32F251458F05EF977DABF39CDC8F06F3793B378956BE70A5FD0B9`。

公開予定リポジトリ: https://github.com/childalabo/CapFrameX-PMCReader

## 導入と復元

検証または配布が許可された環境で、CapFrameX を通知領域も含めて完全に終了します。既存の `CapFrameX.PmcReader.Plugin.dll` を別の安全な場所にバックアップし、試験済み DLL が別途配布された場合は、その DLL を `CapFrameX.exe` と同じフォルダーに配置します。このリポジトリには DLL は含まれません。試験環境では管理者として起動しました。Clam PmcReader を含む他の PMC 計測ツールとの同時使用は避けてください。

元に戻すには CapFrameX を完全に終了し、配置した DLL をバックアップした元の DLL に戻します。元の DLL がなかった場合は、追加した DLL を取り除きます。WinRing0 の共有デバイスのアンロードや PMC 状態の復元を保証する操作ではありません。

## セキュリティと制限

WinRing0 は Microsoft が CVE-2020-14979 に関連する既知の脆弱なドライバーと分類しており、Windows により読み込みが制限される場合があります。保護機能の無効化は案内しません。

PMC・HWCR の原状復元と他ツールとの完全な排他保証はありません。個別センサーの選択に関係なく L2・L3・DRAM の PMC が初期化されます。異常終了や他ツールとの競合は未検証です。

## ソースとライセンス

`source/` は試験済み DLL のビルド元に対応します。22 ファイルには後から変更表示のコメントのみを追加しており、元の MPL 表示は保持しています。ドライバーファイルはソースフォルダーに含まれていないため、このフォルダーだけではビルドできません。`BUILD.md` と `NOTICE.md`、`licenses/` を参照してください。

`CaptureLifetimeGate.cs` などの新規作成部分は、第三者のコードや権利を含まない範囲で MIT の条件を適用し、`Copyright (c) 2026 childalabo` と表示します。既存の第三者ライセンスと表示を保持します。詳細は `NOTICE.md` と `licenses/LICENSE-New-Project-Code.txt` を参照してください。
