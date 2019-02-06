# Boiling

- 2019/02/07
- dotnet 2.2.101
- 無瑕疵程式碼 Ch6

```powershell
### 1. 建立專案
> mkdir DemoBoiling
> cd DemoBoiling
> dotnet new sln
> mkdir Frame       # 主類別    dotnet new classlib
> mkdir FrameTest   # 測試      dotnet new nunit

### 2-1. 建立主類別
> cd Frame
> dotnet new classlib
> cd ..

### 2-2. 建立測試
> cd FrameTest
> dotnet new nunit
> dotnet add reference ../Frame/Frame.csproj
> cd ..

### 3. 建立相依性
> dotnet sln add Frame/Frame.csproj
> dotnet sln add FrameTest/FrameTest.csproj

### 4. Rename
# 4-1. 主類別 & 測試段, XXX.cs 重命名
# 4-2. 主類別 namespace, ex: Boiling
# 4-3. 測試段 namespace, ex: Boiling.Tests (可不與要測試的類別同名)
# 4-4. 測試段 using 主類別 的 namespace, 即: using Boiling;
# 4-5. 主類別 namespace 與其內的 class name, 盡量別同名(不確定)

### 5. Coding Test
> dotnet test
```