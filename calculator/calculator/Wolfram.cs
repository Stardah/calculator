using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolframAlphaNET;
using WolframAlphaNET.Objects;

namespace calculator
{
    class Wolfram
    {
        WolframAlpha wolfram = new WolframAlpha("2PPA96-P9K79VET4P");
        QueryResult results;
        StringBuilder sb;
        public string SolveThis(string info)
        {
            results = wolfram.Query(info);

            sb = new StringBuilder();
            if (results != null)
            {
                foreach (Pod pod in results.Pods)
                {
                    sb.Append(pod.Title);
                    if (pod.SubPods != null)
                    {
                        foreach (SubPod subPod in pod.SubPods)
                        {
                            sb.Append(subPod.Title);
                            sb.Append(subPod.Plaintext);
                        }
                    }
                }
            }
            return Parse(sb.ToString());
        }

        public List<string> SolveSystem(string info)
        {
            results = wolfram.Query(info);

            sb = new StringBuilder();
            if (results != null)
            {
                foreach (Pod pod in results.Pods)
                {
                    sb.Append(pod.Title);
                    if (pod.SubPods != null)
                    {
                        foreach (SubPod subPod in pod.SubPods)
                        {
                            sb.Append(subPod.Title);
                            sb.Append(subPod.Plaintext);
                        }
                    }
                }
            }

            return ParseSystem(sb.ToString());
        }

        List<string> ParseSystem(string info)
        {
            List<string> result = new List<string>();
            if (info.Contains("Result"))
            {
                info = info.Remove(0, info.IndexOf("Result"));
                int x1 = info.IndexOf("X1 = ");
                int x2 = info.IndexOf("X2 = ");
                int x3 = info.IndexOf("X3 = ");
                result.Add(info.Substring(x1 + 5, x2 - x1-10));
                result.Add(info.Substring(x2 + 5, x3 - x2-10));
                result.Add(info.Substring(x3 + 5));
            }
            else
            {
                result.Add("C1");

                result.Add("C2");

                result.Add("C3");
            }
            return result;

        }

        string Parse(string info)
        {
            if (info.Contains("Decimal"))
                {
                    info = info.Remove(0, info.IndexOf("Decimal") + 7 + 14);
                }
                else if (info.Contains("Result")) info = info.Remove(0, info.IndexOf("Result") + 6);
                else return "";
            int i = 0;
            foreach (char ch in info)
            {
                if (!char.IsDigit(ch) && ch != ',' && ch!= '.')
                {
                    info = info.Remove(i,info.Length-i);
                    break;
                }
                i++;
            }
            return info;
        }
    }
}
