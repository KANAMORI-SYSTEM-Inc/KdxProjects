# KdxProjects 更新クイックガイド

## 🚀 クイックスタート（最も一般的なケース）

### バグフィックス（1.0.0 → 1.0.1）

```powershell
# 1. KdxProjectsで変更を加える
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxProjects
# コードを編集...プルリクエスト作成

# 2. コミット
cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxProjects
git add .
git commit -m "Fix: [変更内容の説明]"
git tag -a v1.0.1 -m "Release v1.0.1"

cd C:\Users\amdet\source\repos\KANAMORI-SYSTEM-Inc\KdxDesigner
git add src/KdxDesigner/KdxDesigner.csproj
git commit -m "Update KdxProjects packages to v1.0.1"
```

## 📊 バージョニングチートシート

| 変更タイプ | バージョン | コマンド例 |
|-----------|----------|-----------|
| 🐛 バグ修正 | `1.0.0` → `1.0.1` | `.\update-kdxprojects.ps1 -NewVersion "1.0.1"` |
| ✨ 新機能（互換） | `1.0.1` → `1.1.0` | `.\update-kdxprojects.ps1 -NewVersion "1.1.0"` |
| 💥 破壊的変更 | `1.1.0` → `2.0.0` | `.\update-kdxprojects.ps1 -NewVersion "2.0.0"` |

