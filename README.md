# dotnet.helloworld

## 專案架構

- **webapi/**
  應用層，包含 Controller，處理 API 請求
- **webapi.services/**
  服務層，處理商業邏輯
- **webapi.models/**
  資料模型層，定義 DTO / Entity
- **webapi.core/**
  核心層，定義共用邏輯與介面

## 技術重點

- .NET Core Web API
- 分層架構設計：清楚區分 Controller、Service、Model 與 Core
- RESTful API 設計：簡單、易於擴充
- 資料庫整合 (可擴充 EF Core)
 -可維護性：程式碼結構清楚，便於測試與維護
