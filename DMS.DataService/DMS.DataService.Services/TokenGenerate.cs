using System;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.Security.Cryptography;
using NEXA.DataService.Services;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Configuration;

namespace DMS.DataService.Services
{
    public class TokenGenerate
    {
        //public JWTAPIToken GenerateRefreshToken(string UserId, string Password)
        //{
        //    return GenerateJWTTokens(UserId, Password);
        //}

        //public JWTAPIToken GenerateJWTTokens(string UserId, string Password)
        //{
        //    try
        //    {
        //        string jwtSecret = Convert.ToString(ConfigurationManager.AppSettings["jwtSecret"]);
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var tokenKey = Encoding.UTF8.GetBytes(jwtSecret);
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new[]
        //        {
        //        new Claim(ClaimTypes.NameIdentifier, UserId),
        //        new Claim(ClaimTypes.Name, Password)
        //    }),
        //            Expires = DateTime.UtcNow.AddMinutes(30),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        var refreshToken = GenerateRefreshToken();
        //        return new JWTAPIToken { Access_Token = tokenHandler.WriteToken(token), Refresh_Token = refreshToken };
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        return Convert.ToBase64String(randomNumber);
        //    }
        //}

        //public ServiceHeaderInfo1 GetPrincipalFromExpiredToken(string token)
        //{
        //    string jwtSecret = Convert.ToString(ConfigurationManager.AppSettings["jwtSecret"]);
        //    ServiceHeaderInfo1 serviceHeader = new ServiceHeaderInfo1();
        //    var Key = Encoding.UTF8.GetBytes(jwtSecret);
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = false,
        //        ValidateAudience = false,
        //        ValidateLifetime = false,
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(Key),
        //        ClockSkew = TimeSpan.Zero,
        //        RequireExpirationTime = true
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        //    JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
        //    if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        //throw new SecurityTokenException("Invalid token");
        //        serviceHeader.Message = "Invalid Token";
        //        serviceHeader.IsAuthenticated = false;
        //    }
        //    var expClaim = principal.Claims.First(x => x.Type == "exp").Value;
        //    var userid = principal.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        //    var passwrd = principal.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
        //    var tokenExpiryTime = Convert.ToInt64(expClaim);
        //    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(tokenExpiryTime);
        //    if (dateTimeOffset < DateTime.UtcNow)
        //    {
        //        serviceHeader.Message = "Token Expired";
        //        serviceHeader.IsAuthenticated = false;
        //    }
        //    else
        //    {
        //        serviceHeader.Message = "Token Validated";
        //        serviceHeader.IsAuthenticated = true;
        //    }
        //    return serviceHeader;
        //}

        //public ServiceHeaderInfo1 AuthenticateJWTToken(IncomingWebRequestContext requestContext)
        //{
        //    ServiceHeaderInfo1 headerInfo = new ServiceHeaderInfo1();
        //    System.Net.WebHeaderCollection headerCollection = requestContext.Headers;
        //    string authorization = requestContext.Headers["Authorization"];
        //    //If we don't find the authorization header return null
        //    if (string.IsNullOrEmpty(authorization))
        //    {
        //        return null;
        //    }
        //    //get the token from the auth header
        //    if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        //    {
        //        headerInfo.Token = authorization.Substring("Bearer ".Length).Trim();
        //    }
        //    return GetPrincipalFromExpiredToken(headerInfo.Token);
        //}



        public static string GenearteXMLDealerFile(string username, string password)
        {
            string path = HttpRuntime.AppDomainAppPath;
            string folder = Path.Combine(path, Path.Combine("DealerDetails.xml"));
            string getToken = GenerateToken(username);
            if (!File.Exists(folder))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(folder, xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Dealers");
                    xmlWriter.WriteStartElement("Dealer");
                    xmlWriter.WriteElementString("username", username);
                    xmlWriter.WriteElementString("token", getToken);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load(folder);

                //first it will check if exist then update the token
                var items = from item in xDocument.Descendants("Dealer")
                            where item.Element("username").Value == username
                            select item;
                if (items.Count() > 0)
                {
                    foreach (XElement itemElement in items)
                    {
                        itemElement.SetElementValue("token", getToken);
                    }
                    xDocument.Save(folder);
                }
                else
                {

                    XElement root = xDocument.Element("Dealers");
                    IEnumerable<XElement> rows = root.Descendants("Dealer");
                    XElement firstRow = rows.First();
                    firstRow.AddBeforeSelf(
                       new XElement("Dealer",
                       new XElement("username", username),
                       new XElement("token", getToken))
                      );
                    xDocument.Save(folder);
                }
            }
            return getToken;
        }

        public static string GenerateToken(string username)
        {
            var randomNumber = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                var UserName = username;
                var RandomNumber = Convert.ToBase64String(randomNumber);
                var CreatedTime = System.DateTime.Now;
                string Token = String.Format("{0}|{1}|{2}", UserName, RandomNumber, CreatedTime);
                return EncryptWithGcm(Token);
            }
        }

        public static string EncryptWithGcm(string plainText)
        {
            //string PhraseKey = ConfigurationManager.AppSettings["PhraseKey"];
            string PhraseKey = "40887952454045cb9a70040a30e2d005";
            //string IvKey = ConfigurationManager.AppSettings["IvKey"];
            string IvKey = "@1B2c3D4e5F6g7H8";
            // converts a C# string to a byte array
            byte[] ivbytes = Encoding.ASCII.GetBytes(IvKey);
            byte[] keybytes = Encoding.ASCII.GetBytes(PhraseKey);

            var instance = CipherUtilities.GetCipher("AES/GCM/NoPadding");
            instance.Init(true, new AeadParameters(new KeyParameter(keybytes), 128, ivbytes));

            var plainTextData = Encoding.ASCII.GetBytes(plainText);
            var cipherText = instance.DoFinal(plainTextData);
            return Convert.ToBase64String(cipherText);
        }

        public static string GetDecryptedString(string _value)
        {
            try
            {
                if (string.IsNullOrEmpty(_value))
                {
                    _value = string.Empty;
                }
                else if (!string.IsNullOrEmpty(_value) && !"null".Equals(_value))
                {
                    //_value = DecryptString(_value);// Code commented by kritika kulariya
                    var Suffix = _value.Length > 4 ? _value.Substring(_value.Length - 4) : _value;
                    if (Suffix.ToLower() == "@gcm")
                    {
                        _value = _value.Substring(0, _value.Length - 4);
                        _value = DecryptWithGcm(_value);
                    }
                    else
                    {
                        _value = DecryptString(_value);
                        _value = !(string.IsNullOrEmpty(_value)) ? (_value.Replace(@"\", @"\\").Replace(@"""", "").Replace(@"'", "\'")).Trim() : "";
                    }
                }

            }
            catch (Exception ex)
            {
                //_value = "";
                //Logger.Log("[" + _value + "] GetDecryptedString:: " + ex.ToString());
            }
            return _value;
        }

        public static String DecryptWithGcm(string cipherText1)
        {
            //string PhraseKey = ConfigurationManager.AppSettings["PhraseKey"];
            string PhraseKey = "40887952454045cb9a70040a30e2d005";
            //string IvKey = ConfigurationManager.AppSettings["IvKey"];
            string IvKey = "@1B2c3D4e5F6g7H8";

            byte[] RawBytes = Convert.FromBase64String(cipherText1);

            // converts a C# string to a byte array
            byte[] ivbytes = Encoding.ASCII.GetBytes(IvKey);
            byte[] keybytes = Encoding.ASCII.GetBytes(PhraseKey);

            var instance = CipherUtilities.GetCipher("AES/GCM/NoPadding");
            instance.Init(false, new AeadParameters(new KeyParameter(keybytes), 128, ivbytes));
            var decryptedData = instance.DoFinal(RawBytes);
            return Encoding.UTF8.GetString(decryptedData);
        }

        public static string DecryptString(string base64StringToDecrypt)
        {
            //string /*passphrase*/ = ConfigurationManager.AppSettings["PhraseKey"];
            string passphrase = "40887952454045cb9a70040a30e2d005";
            string plaintext = "";
            //Set up the encryption objects           
            using (AesCryptoServiceProvider acsp = GetProvider(Encoding.UTF8.GetBytes(passphrase)))
            {
                byte[] RawBytes = Convert.FromBase64String(base64StringToDecrypt);
                if (RawBytes == null)
                {
                    return plaintext;
                }
                ICryptoTransform ictD = acsp.CreateDecryptor();
                //RawBytes now contains original byte array, still in Encrypted state 
                //Decrypt into stream               
                MemoryStream msD = new MemoryStream(RawBytes);
                CryptoStream csD = new CryptoStream(msD, ictD, CryptoStreamMode.Read);
                ///csD now contains original byte array, fully decrypted               
                ///return the content of msD as a regular string                
                ///return (new StreamReader(csD)).ReadToEnd();               
                using (StreamReader str = new StreamReader(csD))
                {
                    plaintext = str.ReadToEnd();
                }
                return plaintext;
            }
        }

        private static AesCryptoServiceProvider GetProvider(byte[] key)
        {
            AesCryptoServiceProvider result = new AesCryptoServiceProvider();
            result.BlockSize = 128;
            result.KeySize = 256;
            result.Padding = PaddingMode.PKCS7;
            //result.GenerateIV();            
            //@1B2c3D4e5F6g7H8           
            result.IV = Encoding.UTF8.GetBytes("@1B2c3D4e5F6g7H8");
            //byte[] RealKey = GetKey(key, result);           
            result.Key = key;
            // result.IV = RealKey;           
            return result;

        }

        public static ServiceHeaderInfo1 ValidateToken(string token, string type)
        {
            //string path = HttpRuntime.AppDomainAppPath;
            string path = ConfigurationManager.AppSettings["DealerDetails"].ToString();
            string folder = Path.Combine(path, Path.Combine("DealerDetails.xml"));
            string path_Mtab = ConfigurationManager.AppSettings["DealerDetails_Mtab"].ToString();
            ServiceHeaderInfo1 serviceHeaderInfo = new ServiceHeaderInfo1();
            bool flag = false;
            string fileContent = "";
            string textFilePath = ConfigurationManager.AppSettings["PullTokenpath"].ToString();
            fileContent = File.ReadAllText(textFilePath).ToString();
            if (fileContent.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                fileContent = fileContent.Substring("Bearer ".Length).Trim();
            }
            if (token == fileContent.Trim().ToString())
            {
                serviceHeaderInfo.IsAuthenticated = true;
                return serviceHeaderInfo;
            }
            if (type != null && type == "mtab")
            {
                ErrorLog.ErrorLogException("Validate Token", "Mtab Block Open", path_Mtab, "MtabPath");
                string folder_mtab = Path.Combine(path_Mtab, Path.Combine("DealerDetails.xml"));
                ErrorLog.ErrorLogException("Validate Token", "folder_mtab", folder_mtab, "MtabPath");
                var TokenVal_Mtab = DecryptWithGcm(token);
                ErrorLog.ErrorLogException("Validate Token", "DecryptToken", TokenVal_Mtab, "MtabPath");
                if (TokenVal_Mtab != null)
                {
                    ErrorLog.ErrorLogException("Validate Token", "If block If token not null", TokenVal_Mtab, "MtabPath");
                    string[] tokenValue_Mtab = TokenVal_Mtab.Split('|');
                    ErrorLog.ErrorLogException("Validate Token", "If block If token not null", "split token", "MtabPath token split");
                    var UserName_Mtab = Convert.ToString(tokenValue_Mtab[0]);
                    ErrorLog.ErrorLogException("Validate Token", tokenValue_Mtab[0].ToString(), UserName_Mtab, "UserName");
                    var CreatedTime_Mtab = Convert.ToString(tokenValue_Mtab[2]);
                    XDocument xDocument_Mtab = XDocument.Load(folder_mtab);
                    ErrorLog.ErrorLogException("Validate Token", "xDocument_Mtab", "load xml", "UserName");
                    var items_mtab = from item in xDocument_Mtab.Descendants("Dealer")
                                     where item.Element("username").Value == UserName_Mtab
                                     select item;

                    ErrorLog.ErrorLogException("Validate Token", items_mtab.FirstOrDefault().ToString(), "load xml", "UserName");
                    if (items_mtab != null)
                    {
                        var xElement = items_mtab.FirstOrDefault();
                        if (xElement != null)
                        {
                            var TokenFromFile = xElement.Element("token").Value;
                            if (TokenFromFile != token)
                            {
                                flag = false;
                            }
                            else
                            {
                                var currentTime = System.DateTime.Now;
                                var tokenCreatedTime = Convert.ToDateTime(CreatedTime_Mtab).AddDays(2);
                                if (tokenCreatedTime < currentTime)
                                {
                                    //Token is expired
                                    flag = false;
                                }
                                else
                                {
                                    flag = true;
                                }
                            }
                        }
                    }
                    serviceHeaderInfo.IsAuthenticated = flag;
                    return serviceHeaderInfo;
                }
                else
                {
                    serviceHeaderInfo.IsAuthenticated = flag;
                    return serviceHeaderInfo;
                }
            }
            else
            {
                var TokenVal = DecryptWithGcm(token);
                if (TokenVal != null)
                {
                    string[] tokenValue = TokenVal.Split('|');
                    var UserName = Convert.ToString(tokenValue[0]);
                    var CreatedTime = Convert.ToString(tokenValue[2]);
                    XDocument xDocument = XDocument.Load(folder);
                    var items = from item in xDocument.Descendants("Dealer")
                                where item.Element("username").Value == UserName
                                select item;
                    if (items != null)
                    {
                        var xElement = items.FirstOrDefault();
                        if (xElement != null)
                        {
                            var TokenFromFile = xElement.Element("token").Value;
                            if (TokenFromFile != token)
                            {
                                flag = false;
                            }
                            else
                            {
                                var currentTime = System.DateTime.Now;
                                var tokenCreatedTime = Convert.ToDateTime(CreatedTime).AddDays(2);
                                if (tokenCreatedTime < currentTime)
                                {
                                    //Token is expired
                                    flag = false;
                                }
                                else
                                {
                                    flag = true;
                                }
                            }
                        }
                    }
                    serviceHeaderInfo.IsAuthenticated = flag;
                    return serviceHeaderInfo;
                }
                else
                {
                    serviceHeaderInfo.IsAuthenticated = flag;
                    return serviceHeaderInfo;
                }
            }

        }


    }
}