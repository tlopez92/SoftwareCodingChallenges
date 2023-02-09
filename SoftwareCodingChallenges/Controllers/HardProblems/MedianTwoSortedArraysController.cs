using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoftwareCodingChallenges.Controllers.HardProblems
{
    public class SortedArraysInput
    {
        public int[] nums1 { get; set; }
        public int[] nums2 { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class MedianTwoSortedArraysController : BaseApiController
    {
        /*
            Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
            The overall run time complexity should be O(log (m+n)).
        */
        [HttpPost("/medianTwoSortedArrays")]
        public IActionResult FindMedianSortedArrays([FromBody] SortedArraysInput input)
        {
            int[] nums1 = input.nums1;
            int[] nums2 = input.nums2;
            // Input: nums1 = [1,3], nums2 = [2]
            // Output: 2.00000
            // Explanation: merged array = [1, 2 ,3] and median is 2.

            // Input: nums1 = [1,2], nums2 = [3,4]
            // Output: 2.50000
            // Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.
            // Input: nums1 = [1,3], nums2 = [2]
            // Output: 2.00000
            // Explanation: merged array = [1, 2 ,3] and median is 2.

            // Input: nums1 = [1,2], nums2 = [3,4]
            // Output: 2.50000
            // Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.
            return Ok(FindMedian(nums1, nums2));     
        }

        private double FindMedian(int[] nums1, int[] nums2)
        {
            int[] merged = new int[nums1.Length + nums2.Length];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                merged[k++] = (nums1[i] < nums2[j]) ? nums1[i++] : nums2[j++];
            }
            while (i < nums1.Length)
            {
                merged[k++] = nums1[i++];
            }
            while (j < nums2.Length)
            {
                merged[k++] = nums2[j++];
            }

            return (merged.Length % 2 == 0) ? (merged[merged.Length / 2] + merged[merged.Length / 2 - 1]) / 2.0 : merged[merged.Length / 2];
        }
    }
}
