namespace _001_VMT.Shared.Helpers.Message;

public static class SharedMessage
{
    #region 001: Api status codes and messages
    public const int Ok = 200;
    public const int Unauthorized = 401;
    public const int NotFound = 404;
    public const int BadRequest = 400;
    public const int InternalError = 500;

    public const string OkMessage = "Ok";
    public const string NotFoundMessage = "Not Found";
    public const string BadRequestMessage = "Bad Request";
    public const string InternalErrorMessage = "Internal Error";

    public const string BadRequestGeneral = "Lo sentimos, Hubo un error al hacer la solicitud";
    public const string InternalErrorGeneral = "Error interno del servidor | Revise su conexion";
    #endregion

    #region 002: Nomenclatures related to cors
    public const string RegisterSuccess = "Se ha registrado exitosamente";
    public const string LoginSuccess = "Ha iniciado sesion exitosamente";
    public const string InvalidCredentials = "Credenciales invalidas";
    #endregion

    #region 003: Nomenclatures related to cors
    public const string CorsPolicies = "Cors:CustomerPolicy";
    public const string ClientUrl = "Cors:ClientUrl";
    #endregion

    #region 004: Nomenclatures related to jwt
    public const string JwtSettings = "JwtSettings";
    public const string JwtKey = "JwtSettings:Key";
    public const string JwtIssuer = "JwtSettings:Issuer";
    public const string JwtAudience = "JwtSettings:Audience";
    #endregion
}