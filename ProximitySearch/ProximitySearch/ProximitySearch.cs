using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    public class ProximitySearch
    {
        public ProximitySearch()
        {

        }
        
        public int FindProximityCount(string keyword1, string keyword2, int range, string fileName)
        {
            if (range < 2)
                return 0;

            try
            {
                //Keep a list of the position the keywords are found in the file, and later use this info to determine proximity
                List<int> kw1PosIndex = new List<int>();
                List<int> kw2PosIndex = new List<int>();

                //Per spec, we can assume that the file is just words delimited by spaces 
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string curWord = string.Empty;
                    int position = 1;
                    
                    //Memory usage should be extremly low, while still suitably fast for our needs
                    if (!sr.EndOfStream || range < 2) //Make sure we don't have an empty file
                    {
                        do
                        {
                            char curChar = (char)sr.Read();

                            if (curChar == ' ' || sr.EndOfStream)
                            {
                                //End of stream, so finish the word
                                if (sr.EndOfStream)
                                {
                                    curWord += curChar;
                                }

                                if (curWord == keyword1)
                                {
                                    //Store the position of the keyword1, once keyword 2 is found, those positions will be used to determine the proximity versus
                                    //the position of keyword2
                                    kw1PosIndex.Add(position);
                                }
                                else if (curWord == keyword2)
                                {
                                    kw2PosIndex.Add(position);
                                }

                                //Reset the current word
                                curWord = string.Empty;
                                position++;
                            }
                            else
                            {
                                curWord += curChar;
                            }
                        } while (!sr.EndOfStream);
                    }

                    //Now we have the index position of both keywords. Let's use this info to determine proximity
                    return CalcProximityFromPositions(kw1PosIndex, kw2PosIndex, range);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"The File {fileName} was not found.", e);
            }
        }

        private int CalcProximityFromPositions(List<int> kw1List, List<int> kw2List, int range)
        {
            int count = 0;
            //Range includes the keyword itself. In order to calculate for that, I need to offset by 1
            range--;
            
            //Get any words to the right and left of keyword1
            kw1List.ForEach(kw1Index =>
                                        {                                
                                            int proximityRange = kw1Index + range;
                                            count += kw2List.Where(kw2Index => (kw2Index > kw1Index) && (kw2Index <= proximityRange)).Count();

                                            proximityRange = kw1Index - range;
                                            if (proximityRange > 0)
                                                count += kw2List.Where(kw2Index => (kw2Index < kw1Index) && (kw2Index >= proximityRange)).Count();

                                        });
            return count;
        }
    }
}
