using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoftwareCodingChallenges.Controllers.HardProblems
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamingCompanyController : BaseApiController
    {
        /*
         * You are given an array of strings ideas that represents a list of names to be used in the process of naming a company. The process of naming a company is as follows:

            Choose 2 distinct names from ideas, call them ideaA and ideaB.
            Swap the first letters of ideaA and ideaB with each other.
            If both of the new names are not found in the original ideas, then the name ideaA ideaB (the concatenation of ideaA and ideaB, separated by a space) is a valid company name.
            Otherwise, it is not a valid name.
            Return the number of distinct valid names for the company.
        */
        [HttpPost("/namingCompany")]
        public IActionResult NamingCompany([FromBody] string[] ideas)
        {
            Dictionary<char, HashSet<int>> count = new ();

            foreach (string idea in ideas)
            {
                char firstLetter = idea[0];
                string restOfWord = idea.Substring(1);
                int hashValue = restOfWord.GetHashCode();

                if(!count.ContainsKey(firstLetter))
                {
                    count.Add(firstLetter, new HashSet<int>());
                }
                count[firstLetter].Add(hashValue);
            }

            long result = 0;
            foreach (var item in count)
            {
                foreach (var item2 in count)
                {
                    if (item.Key >= item2.Key)
                    {
                        continue;
                    }
                    int same = item.Value.Intersect(item2.Value).Count();

                    result += (item.Value.Count - same) * (item2.Value.Count - same);
                }
            }
            return Ok(result * 2);
        }
    }
}
