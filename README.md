
# Asp.Net Core MVC Api With JWT Bearer

TR

Asp.Net Core teknolojisi ve MVC mimarisi ile yazılmış JWT token doğrulama sistemini kullanan api projesi.
Bu projede önce kayıt ve giriş işlemi yapıp yetkiye göre veri çekme işlemi gerçekleştiriliyor. Bu işlem JWT Bearer yetkilendirme sistemi ile yapılmıştır. Kayıt olup giriş yaptıktan sonra giriş yapan kullanıcıya bir token verilir bu token sunucunun hafızasında tutulmaktadır. Kullanıcı giriş yaptığında bu token api tarafından kontrol edilir ve eğer doğrulama başarılı ise kullanıcı verileri çekebilir.

EN

API project using Asp.Net Core technology and MVC architecture with a JWT token authentication system. In this project, registration and login processes are first carried out, followed by data retrieval based on user permissions. This is achieved using the JWT Bearer authorization system. After registering and logging in, the user is issued a token, which is stored in the server's memory. When the user logs in, this token is verified by the API, and if the authentication is successful, the user can retrieve their data.
## Kullanılan Teknolojiler Ve Mimari / Technologies Used and Architecture

- Katmanlı Mimari / Onion Pattern
- Json Web Token Authentication (JWT)
- Asp.Net Core 7
- Identity Authorization
- Entity Framework Core
- MS Sql
- Generic Repository
- Unit Of Work
- LINQ


  
## API Kullanımı

#### Kayıt Ol / Register

```http
  POST api/Account/Register
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `Id`      | `string` |            Id              |
|`FirstName`| `string` |            FirstName       |
|`LastName`| `string` |            LastName       |
|`UserName`| `string` |            UserName       |
|`Phone`| `string` |            Phone       |
|`Email`| `string` |            Email       |
|`Password`| `string` |            Password       |
|`ConfirmPassword`| `string` |            ConfirmPassword       |

#### Giriş / Login

```http
  POST api/Account/Login
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `UserName` | `string` | UserName |
| `Password` | `string` | Password |

#### Tüm öğeleri getir / Get All

```http
  POST api/Employee
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `Id` | `int` | Id |
| `FirstName` | `string` | FirstName |
| `LastName` | `string` | LastName |
| `PhoneNumber` | `string` | PhoneNumber |
| `Email` | `string` | Email |


#### Id'sine göre öğeyi getir / Get By Id

```http
  GET /api/Employee/${id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Gerekli**. Çağrılacak öğenin anahtar değeri |


  
