# Changelog

このファイルは、KdxProjectsの注目すべき変更をすべて記録します。

フォーマットは [Keep a Changelog](https://keepachangelog.com/ja/1.0.0/) に基づいており、
このプロジェクトは [Semantic Versioning](https://semver.org/lang/ja/) に準拠しています。

## [Unreleased]

## [1.0.0] - 2025-10-02

### Added
- 初回リリース
- Kdx.Contracts v1.0.0 - DTOとインターフェースの定義
- Kdx.Core v1.0.0 - ビジネスロジックとアプリケーションサービス
  - IProcessFlowService - プロセスフロー管理サービス
  - IInterlockValidationService - インターロック検証サービス
- Kdx.Infrastructure v1.0.0 - インフラストラクチャサービスの実装
  - ProcessFlowService - プロセスフロー管理の実装
  - InterlockValidationService - インターロック検証の実装
- Kdx.Infrastructure.Supabase v1.0.0 - Supabase固有のリポジトリ実装
  - SupabaseRepository - Supabase接続とデータアクセス
- Kdx.Contracts.ViewModels v1.0.0 - WPF ViewModelsの契約

### Changed
- モノリポから独立したNuGetパッケージリポジトリに分離

### Technical
- .NET 8.0対応
- NuGetパッケージ生成機能を追加
- CI/CDパイプライン設定（GitHub Actions）
