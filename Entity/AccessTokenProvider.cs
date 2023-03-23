using TestWebApp2.Models;

namespace TestWebApp2.Entity;

public sealed class AccessTokenProvider
{
    private static AccessTokenProvider instance;
    private static object lockObj = new Object();
    private AccessTokenModel accessTokenModel;
    private AccessTokenProvider() { }
    public static AccessTokenProvider Instance
    {
        get
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new AccessTokenProvider();
                }
                return instance;
            }
        }
    }

    public AccessTokenModel? GetToken()
    {
        if (accessTokenModel == null){
            accessTokenModel = OAuthHandler.GetAccessTokenAsync().Result;
        }

        return accessTokenModel;
    }


}