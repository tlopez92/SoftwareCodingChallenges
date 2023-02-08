using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoftwareCodingChallenges.Controllers.EasyProblems
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoNumberSumController : BaseApiController
    {
        /// <summary>
        /// Time Complexity O(n^2)
        /// Space Complexity O(1)
        /// </summary>
        /// [1, 2, 3, 4,5, 6, 7,....,n]
        [HttpPost("/twoNumberSum_1/targetSum/{targetSum:int}")]
        public IActionResult TwoNumberSum_1([FromBody] List<int> numbers, int targetSum)
        {
            int x = targetSum;
            for (int i = 0; i < numbers.Count - 2; i++)
            {
                for (int j = i + 1; j < numbers.Count - 1; j++)
                {
                    if (numbers[i] + numbers[j] == targetSum)
                        return Ok(new List<int>(new int[] { numbers[i], numbers[j] }));
                }
            }
            return Ok(new List<int>());
        }

        /// <summary>
        /// Time Complexity O(n)
        /// Space Complexity O(n)
        /// </summary>
        [HttpPost("/twoNumberSum_2/targetSum/{targetSum:int}")]
        public IActionResult TwoNumberSum_2([FromBody] List<int> numbers, int targetSum)
        {
            HashSet<int> nums = new HashSet<int>();
            foreach (var number in numbers)
            {
                int potential = targetSum - number;
                if (nums.Contains(potential))
                    return Ok(new List<int>(new int[] { potential, number }));
                else
                {
                    nums.Add(number);
                }
            }
            return Ok(new List<int>());
        }

        /// <summary>
        /// Time Complexity O(nlogn)
        /// Space Complexity O(1)
        /// </summary>
        /// [1, 2, 3, 4,.....10,....n]
        [HttpPost("/twoNumberSum_3/targetSum/{targetSum:int}")]
        public IActionResult TwoNumberSum_3([FromBody] List<int> numbers, int targetSum)
        {
            numbers.Sort();
            int left = 0;
            int right = numbers.Count - 1;

            while (left < right)
            {
                if (numbers[left] + numbers[right] == targetSum)
                    return Ok(new List<int>(new int[] { numbers[left], numbers[right] }));
                if (numbers[left] + numbers[right] > targetSum)
                    right--;
                if (numbers[left] + numbers[right] < targetSum)
                    left++;
            }
            return Ok(new List<int>());
        }
    }
}
