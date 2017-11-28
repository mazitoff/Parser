using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            const string TxtInfoHeader = "Text:";
            const string ImgInfoHeader = "Image:";
            const string MovInfoHeader = "Movie:";

            string strInfo = @"Text:file.txt(6B);Some string content
            Image:img.bmp(19MB);1920х1080
            Movie:killer66.mkv(4GB);1922х1082;1h58m
            Text:data.txt(12B);Another string
            Image:river.bmp(27MB);720х480
            Text:data1.txt(7B);Yet another string
            Movie:logan.2017.mkv(19GB);1920х1080;2h12m
            Text:data21.txt(47B);Yet another string_887";

            Settings settings = new Settings();
            TextFileList textFileList = new TextFileList();
            ImageFileList imageFileList = new ImageFileList();
            MovieFileList movieFileList = new MovieFileList();
            TextFileInfo textFileInfo; // = new TextFileInfo();
            ImageFileInfo imageFileInfo; // = new ImageFileInfo();
            MovieFileInfo movieFileInfo; // = new MovieFileInfo();
            string action = "DefineTypeInfo";
            string curStr = "";
            char separate = new char();
            int indexSeparate = 0;
            int countSeparates = 0;
            string name = "";
            string extension = "";
            string size = "";
            string content = "";
            string resolutionX = "";
            string resolutionY = "";
            string lenghtHH = "";
            string lenghtMM = "";
            bool endDefine = false;
            string fullName = "";

            for (int i = 0; i < strInfo.Length; i++)
            {
                //Console.WriteLine("                        === {0} - {1}", strInfo[i], (int)strInfo[i]);
                if (curStr.Length == 1)
                {
                    if (curStr == " " || curStr[0] == (char)10 || curStr[0] == (char)13 || curStr[0] == (char)9)
                    {
                        curStr = "";
                    }
                }

                if (action == "DefineTypeInfo")
                {
                    curStr = curStr + strInfo[i];
                    //Console.WriteLine("action = {0}, curStr = {1}", action, curStr);

                    if (curStr == TxtInfoHeader)
                    {
                        action = "DefineDetailInfoForTxt";
                        //Console.WriteLine("           --- Begin gather txt info");
                        curStr = "";
                        separate = settings.SeparatesTxt[indexSeparate++];
                        countSeparates = settings.CountSeparatesTxt;
                    }
                    else if (curStr == ImgInfoHeader)
                    {
                        action = "DefineDetailInfoForImg";
                        //Console.WriteLine("           --- Begin gather img info");
                        curStr = "";
                        separate = settings.SeparatesImg[indexSeparate++];
                        countSeparates = settings.CountSeparatesImg;
                    }
                    else if (curStr == MovInfoHeader)
                    {
                        action = "DefineDetailInfoForMov";
                        //Console.WriteLine("           --- Begin gather mov info");
                        curStr = "";
                        separate = settings.SeparatesMov[indexSeparate++];
                        countSeparates = settings.CountSeparatesMov;
                    }
                }
                else if (strInfo[i] == separate || i == strInfo.Length - 1)
                {
                    //Console.WriteLine("separate num = {0}, curStr = {1}", indexSeparate, curStr);
                    //Console.WriteLine("find separate {0}", separate);
                    endDefine = false;
                    if (indexSeparate <= countSeparates)
                    {
                        if (action == "DefineDetailInfoForTxt")
                        {
                            //if (indexSeparate == 1)
                            //{
                            //    name = curStr;
                            //}
                            if (indexSeparate == 1)
                            {
                                fullName = curStr;
                                GetNameAndExtension(fullName, out name, out extension);
                            }                            //else if (indexSeparate == 2)
                            //{
                            //    extension = curStr;
                            //}
                            else if (indexSeparate == 2)
                            {
                                size = curStr;
                            } 
                            else if (indexSeparate == 4)
                            {
                                content = curStr;
                                endDefine = true;
                            }
                            if (endDefine == false)
                            {
                                separate = settings.SeparatesTxt[indexSeparate++];
                            }
                        }
                        else if (action == "DefineDetailInfoForImg")
                        {
                            //if (indexSeparate == 1)
                            //{
                            //    name = curStr;
                            //}
                            if (indexSeparate == 1)
                            {
                                fullName = curStr;
                                GetNameAndExtension(fullName, out name, out extension);
                            }                            //else if (indexSeparate == 2)
                            //else if (indexSeparate == 2)
                            //{
                            //    extension = curStr;
                            //}
                            else if (indexSeparate == 2)
                            {
                                size = curStr;
                            }
                            else if (indexSeparate == 4)
                            {
                                resolutionX = curStr;
                            }
                            else if (indexSeparate == 5)
                            {
                                resolutionY = curStr;
                                endDefine = true;
                            }
                            if( endDefine == false)
                            {
                                separate = settings.SeparatesImg[indexSeparate++];
                            }
                            
                        }
                        else if (action == "DefineDetailInfoForMov")
                        {
                            //if (indexSeparate == 1)
                            //{
                            //    name = curStr;
                            //}
                            if (indexSeparate == 1)
                            {
                                fullName = curStr;
                                GetNameAndExtension(fullName, out name, out extension);
                            }                            //else if (indexSeparate == 2)
                            //else if (indexSeparate == 2)
                            //{
                            //    extension = curStr;
                            //}
                            else if (indexSeparate == 2)
                            {
                                size = curStr;
                            }
                            else if (indexSeparate == 4)
                            {
                                resolutionX = curStr;
                            }
                            else if (indexSeparate == 5)
                            {
                                resolutionY = curStr;
                            }
                            else if (indexSeparate == 6)
                            {
                                lenghtHH = curStr;
                            }
                            else if (indexSeparate == 7)
                            {
                                lenghtMM = curStr;
                                endDefine = true;
                            }
                            if (endDefine == false)
                            {
                                separate = settings.SeparatesMov[indexSeparate++];
                            }
                            
                        }

                    }
                    if (endDefine == true)
                    {
                        if (action == "DefineDetailInfoForTxt")
                        {
                            textFileInfo = new TextFileInfo(name, extension, size, content);
                            textFileList.Add(textFileInfo);
                        }
                        else if (action == "DefineDetailInfoForImg")
                        {
                            imageFileInfo = new ImageFileInfo(name, extension, size, resolutionX, resolutionY);
                            imageFileList.Add(imageFileInfo);
                        }
                        else if (action == "DefineDetailInfoForMov")
                        {
                            movieFileInfo = new MovieFileInfo( name, extension, size, content, resolutionX, resolutionY, lenghtHH, lenghtMM);
                            movieFileList.Add(movieFileInfo);
                        }
                        action = "DefineTypeInfo";
                        indexSeparate = 0;
                    }
                    curStr = "";
                }
                else
                {
                    curStr = curStr + strInfo[i];
                    //Console.WriteLine("action = {0}, curStr = {1}", action, curStr);
                }

            };
            Console.WriteLine("************************************************************************");
            Console.WriteLine("************************** R E S U L T *********************************");
            Console.WriteLine("************************************************************************");
            Console.WriteLine("************************************************************************");
            textFileList.Print();
            //Console.WriteLine("************************************************************************");
            movieFileList.Print();
            //Console.WriteLine("************************************************************************");
            imageFileList.Print();
            Console.WriteLine("************************************************************************");
            Console.ReadKey();
        }
        static private void GetNameAndExtension(string name, out string body, out string extension)
        {
            body = "";
            extension = "";
            bool foundDot = false;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                if (foundDot == false)
                {
                    if (name[i] == '.')
                    {
                        foundDot = true;
                    }
                    else
                    {
                        extension = name[i] + extension;
                    }
                }
                else
                {
                    body = name[i] + body;
                }
                //Console.WriteLine(name[i]);
            }
        }
    }
}
