namespace EgressPortal.Models;

public static class RouteSettings
{
    public static string HomeRoute = "/";
    public static string EgressRoute = "egressos";
    public static string ProfileEgressRoute = "perfil-egressos";
    public static string TestimonyRoute = "depoimentos";
    public static string HighlightsRoute = "destaques";
    public static string ContactRoute = "contatos";
    public static string LoginRoute = "login";
    public static string RegisterRoute = "cadastrar";
    public static string CompleteRegisterRoute = "/completar-cadastro";
    public static string RecoveryPasswordRoute = "recuperar-senha";
    public static string InstagramRoute = "https://instagram.com/colcic_uesc";
    public static string FacebookRoute = "https://www.facebook.com/colcic.uesc?mibextid=LQQJ4d";
  
    public static string AuthStartPage = "me";
    public static string AuthMyTestimony = $"{AuthStartPage}/meus-depoimentos";
    public static string AuthMyHighlights = $"{AuthStartPage}/meus-destaques";
    public static string AuthUpdate = $"{AuthStartPage}/meus-dados";

    public static string AdminStartPage = "admin";
    public static string AdminEgressRoute = $"{AdminStartPage}/egressos";
    public static string AdminAddEgressRoute = $"{AdminStartPage}/adicionar-egresso";
    public static string AdminApprovalPersonRoute = $"{AdminStartPage}/pessoas";
    public static string AdminApprovalTestimonyRoute = $"{AdminStartPage}/depoimentos";
    public static string AdminApprovalHighlightsRoute = $"{AdminStartPage}/destaques";
}