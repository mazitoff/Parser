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
            Text:data.txt(12B);Another string
            Text:data1.txt(7B);Yet another string
            Movie:logan.2017.mkv(19GB);1920х1080;2h12m
            Text:data21.txt(47B);Yet another string_887";

            FileList fileList = new FileList();
            TextFileList textFileList = new TextFileList();
            ImageFileList imageFileList = new ImageFileList();
            MovieFileList movieFileList = new MovieFileList();
            TextFileInfo textFileInfo = new TextFileInfo();
            ImageFileInfo imageFileInfo = new ImageFileInfo();
            MovieFileInfo movieFileInfo = new MovieFileInfo();
            string action = "DefineTypeInfo";
            string curStr = "";
            char separate = new char();
            int indexSeparate = 0;
            int countSeparates = 0;

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
                        Console.WriteLine("           --- Begin gather txt info");
                        curStr = "";
                        separate = textFileInfo.Separates[indexSeparate++];
                        countSeparates = textFileInfo.CountSeparates;
                    }
                    else if (curStr == ImgInfoHeader)
                    {
                        action = "DefineDetailInfoForImg";
                        Console.WriteLine("           --- Begin gather img info");
                        curStr = "";
                        separate = imageFileInfo.Separates[indexSeparate++];
                        countSeparates = imageFileInfo.CountSeparates;
                    }
                    else if (curStr == MovInfoHeader)
                    {
                        action = "DefineDetailInfoForMov";
                        Console.WriteLine("           --- Begin gather mov info");
                        curStr = "";
                        separate = movieFileInfo.Separates[indexSeparate++];
                        countSeparates = movieFileInfo.CountSeparates;
                    }
                }
                else if (strInfo[i] == separate || i == strInfo.Length - 1)
                {
                    Console.WriteLine("separate num = {0}, curStr = {1}", indexSeparate, curStr);
                    //Console.WriteLine("find separate {0}", separate);
                    if (indexSeparate <= countSeparates - 1)
                    {
                        if (action == "DefineDetailInfoForTxt")
                        {
                            if (indexSeparate == 1)
                            {
                                textFileInfo.FileName = curStr;
                            }
                            else if (indexSeparate == 2)
                            {
                                textFileInfo.Size = curStr;
                            } 
                            else if (indexSeparate == 4)
                            {
                                textFileInfo.Content = curStr;
                            }
                            separate = textFileInfo.Separates[indexSeparate++];
                        }
                        else if (action == "DefineDetailInfoForImg")
                        {
                            if (indexSeparate == 1)
                            {
                                imageFileInfo.FileName = curStr;
                            }
                            else if (indexSeparate == 2)
                            {
                                imageFileInfo.Size = curStr;
                            }
                            else if (indexSeparate == 4)
                            {
                                imageFileInfo.ResolutionX = curStr;
                            }
                            else if (indexSeparate == 5)
                            {
                                imageFileInfo.ResolutionY = curStr;
                            }
                            separate = imageFileInfo.Separates[indexSeparate++];
                        }
                        else if (action == "DefineDetailInfoForMov")
                        {
                            if (indexSeparate == 1)
                            {
                                movieFileInfo.FileName = curStr;
                            }
                            else if (indexSeparate == 2)
                            {
                                movieFileInfo.Size = curStr;
                            }
                            else if (indexSeparate == 4)
                            {
                                movieFileInfo.ResolutionX = curStr;
                            }
                            else if (indexSeparate == 5)
                            {
                                movieFileInfo.ResolutionY = curStr;
                            }
                            else if (indexSeparate == 6)
                            {
                                movieFileInfo.LenghtHH = curStr;
                            }
                            else if (indexSeparate == 7)
                            {
                                movieFileInfo.LenghtMM = curStr;
                            }
                            separate = movieFileInfo.Separates[indexSeparate++];
                        }

                    }
                    else
                    {
                        if (action == "DefineDetailInfoForTxt")
                        {
                            fileList.Add(textFileInfo);
                            textFileList.Add(textFileInfo);
                            textFileInfo = new TextFileInfo();
                        }
                        else if (action == "DefineDetailInfoForImg")
                        {
                            fileList.Add(imageFileInfo);
                            imageFileList.Add(imageFileInfo);
                            imageFileInfo = new ImageFileInfo();
                        }
                        else if (action == "DefineDetailInfoForMov")
                        {
                            fileList.Add(movieFileInfo);
                            movieFileList.Add(movieFileInfo);
                            movieFileInfo = new MovieFileInfo();
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
            fileList.PrintAll();
            Console.WriteLine("************************************************************************");
            textFileList.Print();
            Console.WriteLine("************************************************************************");
            movieFileList.Print();
            Console.WriteLine("************************************************************************");
            imageFileList.Print();
            Console.WriteLine("************************************************************************");
            Console.ReadKey();
        }
    }
}
