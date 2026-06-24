# AGENTS.md - E-Word-Api 项目上下文

## 项目概述

**E-Word-Api** 是一个英语单词背诵系统的后端 API 服务。

| 属性 | 值 |
|------|-----|
| 技术栈 | .NET 8 / C# / ASP.NET Core Web API |
| 根命名空间 | `E_Word_Api` |
| 数据库 | SQL Server + Entity Framework Core 8 |
| 认证方式 | JWT Bearer + ASP.NET Core Identity |
| API 文档 | Swagger/OpenAPI (开发环境) |
| 默认端口 | localhost:5194 |

## 快速开始

```bash
# 运行项目
dotnet run

# 开发环境运行
dotnet run --environment Development

# 数据库迁移
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

**默认管理员账号**: `admin@eword.com` / `Admin123.`

## 项目结构

```
E-Word-Api/
├── Controllers/              # API 控制器层
│   ├── AccountController.cs  # 用户认证 (注册/登录/获取信息)
│   ├── CET6BookController.cs # 六级词汇书 (分页查询)
│   ├── UserController.cs     # 用户管理 (CRUD/分页/批量删除)
│   └── WordController.cs     # 单词管理 (查询/批量添加)
├── Services/                 # 业务服务层
│   ├── TokenService.cs       # JWT Token 生成服务
│   └── AppUserEmailSender.cs # 邮件发送服务 (空实现)
├── Repositories/             # 数据访问层
│   ├── CET6BookRepository.cs # 六级词汇书数据操作
│   ├── UserRepository.cs     # 用户数据操作
│   └── WordRepository.cs     # 单词数据操作
├── Models/                   # 实体模型
│   ├── AppUser.cs            # 用户实体 (继承 IdentityUser)
│   ├── Word.cs               # 单词实体
│   └── CET6Book.cs           # 六级词汇书实体
├── Dtos/                     # 数据传输对象
│   ├── Cet6BookDto.cs        # 六级词汇书响应
│   ├── LoginUserDto.cs       # 登录请求
│   ├── RegisterUserDto.cs    # 注册请求
│   ├── UpdateUserDto.cs      # 更新用户请求
│   ├── UserDto.cs            # 用户响应
│   ├── TokenClaim.cs         # Token 声明
│   └── WordDto.cs            # 单词请求
├── Datas/                    # 数据库上下文
│   └── EWordDbContext.cs     # EF Core DbContext
├── Utils/                    # 工具类
│   ├── AvatarUtil.cs         # 头像上传工具
│   └── RoleType.cs           # 角色常量定义
├── Migrations/               # EF Core 数据库迁移
├── Statics/                  # 静态文件目录 (头像等)
├── EWord-API/                # API 测试集合 (YAML)
├── Program.cs                # 应用入口和配置
└── appsettings.*.json        # 配置文件
```

## 架构设计

采用 **分层架构**:

```
Controller → Service/Repository → DbContext → SQL Server
```

- **Controllers**: 处理 HTTP 请求，调用服务层
- **Services**: 业务逻辑 (Token 生成、邮件等)
- **Repositories**: 数据访问逻辑
- **Datas**: EF Core 数据库上下文
- **Models**: 数据库实体
- **Dtos**: 请求/响应数据结构

### 依赖注入配置 (Program.cs)

```csharp
// 数据库
builder.Services.AddDbContext<EWordDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<EWordDbContext>()
    .AddDefaultTokenProviders();

// JWT 认证
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => { ... });

// 服务注册
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<WordRepository>();
builder.Services.AddScoped<CET6BookRepository>();
```

## API 端点

### AccountController (`/account`)

| 方法 | 路由 | 认证 | 说明 |
|------|------|------|------|
| POST | `/account/register` | 无 | 用户注册 (支持文件上传) |
| POST | `/account/login` | 无 | 用户登录 |
| GET | `/account/me` | User/Admin | 获取当前用户信息 |

### CET6BookController (`/cet6book`)

| 方法 | 路由 | 认证 | 说明 |
|------|------|------|------|
| GET | `/cet6book/page?number=1&size=20` | User/Admin | 分页获取六级词汇书 |

### UserController (`/user`)

| 方法 | 路由 | 认证 | 说明 |
|------|------|------|------|
| GET | `/user/{id}` | User/Admin | 获取指定用户信息 |
| PUT | `/user/{id}` | User/Admin | 更新用户信息 |
| GET | `/user/list` | User/Admin | 获取所有用户列表 |
| GET | `/user/count` | User/Admin | 获取用户总数 |
| GET | `/user/page?number=1&size=10` | User/Admin | 分页获取用户 |
| DELETE | `/user/batch` | Admin | 批量删除用户 |

### WordController (`/word`)

| 方法 | 路由 | 认证 | 说明 |
|------|------|------|------|
| GET | `/word` | 无 | 获取所有单词 |
| POST | `/word` | User/Admin | 批量添加单词 |

## 数据模型

### AppUser (用户)

```csharp
public class AppUser : IdentityUser
{
    public string? NickName { get; set; }    // 昵称
    public string? City { get; set; }        // 城市
    public DateTime CreatedAt { get; set; }  // 创建时间
    public string? Avatar { get; set; }      // 头像URL
}
```

### Word (单词)

```csharp
public class Word
{
    public string Id { get; set; }           // 主键 (自动生成)
    public string English { get; set; }      // 英文
    public string Chinese { get; set; }      // 中文
    public string[] Options { get; set; }    // 选项数组
}
```

### CET6Book (六级词汇书)

```csharp
public class CET6Book
{
    public long Id { get; set; }
    public string Word { get; set; }
    public string Translate { get; set; }
    public string DistractorWord1-3 { get; set; }    // 干扰词
    public string DistractorTranslate1-3 { get; set; } // 干扰词翻译
}
```

## 认证授权

### JWT 配置

```json
{
  "JWT": {
    "Issuer": "http://localhost:5194",
    "Audience": "http://localhost:5194",
    "SigningKey": "<your-signing-key>"
  }
}
```

### 角色系统

| 角色 | 说明 | 权限 |
|------|------|------|
| `Admin` | 管理员 | 全部权限，可删除用户 |
| `User` | 普通用户 | 查看/更新个人信息，操作单词 |

### Token 声明

```csharp
new Claim("id", user.Id),
new Claim(JwtRegisteredClaimNames.Email, user.Email),
new Claim(JwtRegisteredClaimNames.Name, user.UserName),
new Claim(ClaimTypes.Role, role)
```

**Token 有效期**: 7 天

### 授权使用示例

```csharp
[Authorize(Roles = RoleType.User)]  // User 和 Admin 都可以访问
[Authorize(Roles = RoleType.Admin)] // 仅 Admin 可以访问
```

## 配置文件

### appsettings.Development.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Initial Catalog=eword;User ID=sa;Password=0808;TrustServerCertificate=True"
  },
  "Static": {
    "Url": "http://localhost:5194/statics/"
  }
}
```

## 开发规范

### 代码风格

- 使用 C# 12 主构造函数语法: `public class MyClass(Dependency dep)`
- 命名空间与项目名一致: `E_Word_Api`
- 控制器使用 `[ApiController]` + `[Route("[controller]")]`
- 异步方法使用 `async/await`

### 添加新控制器

1. 在 `Controllers/` 创建控制器类
2. 添加 `[ApiController]` 和 `[Route("[controller]")]` 特性
3. 在 `Program.cs` 中注册服务 (如需要)

### 添加新实体

1. 在 `Models/` 创建实体类
2. 在 `EWordDbContext` 添加 `DbSet<T>`
3. 创建迁移: `dotnet ef migrations add <Name>`
4. 更新数据库: `dotnet ef database update`

### 添加新 DTO

1. 在 `Dtos/` 创建 DTO 类
2. 使用 `[Required]` 等数据注解
3. 在 Controller/Repository 中使用

## 数据库迁移历史

| 迁移 | 说明 |
|------|------|
| `20260428161559_Init` | 初始化: 用户表、角色、种子数据 |
| `20260503062414_WordInit` | 添加单词表 |
| `20260503065229_WordPrimaryKeyAutoGenerated` | 单词主键改为自动生成 |

## 静态文件服务

配置在 `Program.cs`:

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Statics")
    ),
    RequestPath = "/statics"
});
```

**访问方式**: `http://localhost:5194/statics/avatars/{userId}.png`

## 测试 API

项目包含 API 测试集合 (`EWord-API/` 目录):

- `登录.yml` - POST `/account/login`
- `查询所有word.yml` - GET `/word`
- `批量添加word.yml` - POST `/word`

## 注意事项

1. `Statics/` 目录在 `.gitignore` 中被忽略，仅保留 `.gitkeep`
2. `AppUserEmailSender` 是空实现，实际邮件功能未集成
3. 注册接口 `[Authorize]` 被注释掉，当前允许公开注册
4. 获取单词接口 `[Authorize]` 被注释掉，当前允许公开访问
