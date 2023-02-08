using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoftwareCodingChallenges.Controllers.MediumProblems
{
    [Route("api/[controller]")]
    [ApiController]
    public class KadanesAlgorithmController : BaseApiController
    {
        /*
         * Problem Statement:
         * Given an array of integers, find the contiguous subarray with the largest sum.
         * 
         * Example:
         * Input: [-2, 1, -3, 4, -1, 2, 1, -5, 4]
         * Output: 6
         * Explanation: [4, -1, 2, 1] has the largest sum = 6
         * 
         * Input: [1, 2, 3, 4, 5]
         * Output: 15
         * Explanation: [1, 2, 3, 4, 5] has the largest sum = 15
         * 
         * Input: [-1, -2, -3, -4, -5]
         * Output: -1
         * Explanation: [-1] has the largest sum = -1
         * 
         * Input: [1, 2, 3, -4, 5]
         * Output: 9
         * Explanation: [1, 2, 3, -4, 5] has the largest sum = 9
         * 
         * Input: [1, 2, 3, -4, 5, -6, 7]
         * Output: 8
         * Explanation: [1, 2, 3, -4, 5, -6, 7] has the largest sum = 8
         * 
         * Input: [1, 2, 3, -4, 5, -6, 7, -8, 9]
         * Output: 9
         * Explanation: [1, 2, 3, -4, 5, -6, 7, -8, 9] has the largest sum = 9
         * 
         * Input: [1, 2, 3, -4, 5, -6, 7, -8, 9, -10, 11]
         * Output: 11
         * Explanation: [1, 2, 3, -4, 5, -6, 7, -8, 9, -10, 11] has the largest sum = 11
         */
        [HttpPost("/kadanes_algorithm/")]
        public IActionResult ChangeDirectory([FromBody]int[] input)
        {
            int maxSoFar = input[0];
            int maxEndingHere = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                maxEndingHere = Math.Max(input[i], maxEndingHere + input[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return Ok(maxSoFar);
        }
    }
}
