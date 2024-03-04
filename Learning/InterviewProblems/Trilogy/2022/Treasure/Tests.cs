using Common;
using NUnit.Framework;

namespace InterviewProblems.Trilogy._2022.Treasure;

/*
 * In front of you there is a treasure containing many gems, soon you realize that they are not as precious as they seem.
 * In fact, they are cursed with black magic and bring bad luck with them, so you try to minimize the bad luck you get.
 *
 * You have the power to destroy 1 gem in 1 second. You can destroy gems in any order.
 * You are given a 2D array A, where for i-th gem it takes A[i][0] seconds to give A[i][1] units of bad luck.
 * At any instant, only one gem can give the bad luck.
 * And you decide the order with which you want to receive the bad luck.
 * Once the receiving the bad luck starts from any gem, it cannot be destroyed and it automatically vanishes after giving A[i][1] units of bad luck.
 * Although while receiving bad luck from any gem, you can choose to destroy any other gem which is available in treasure.
 * There is no time lapse in between receiving of bad lucks from any two gems. As soon as one gem finishes giving bad luck, you have to choose
 * second gem from the treasure to receive the bad luck.
 * Return the maximum amount of bad luck that you can avoid / destroy.
 *
 * Note: receiving bad luck is a continuous process. And at any instant you cannot receive bad luck from more than one gem. If you are receiving bad
 * luck from any gem, then you can choose second gem only after A[i][0] seconds.
 *
 * Constaints:
 * 1 <= |A| <= 2*10^3
 * |A[i]| == 2
 * 0 <= A[i][0] <= 2*10^3
 * 1 <= A[i][1] <= 10^6
 *
 * Example 1:
 * A = [[ 0, 1 ], [ 0, 10 ]], output: 0. Destroying a gem will take 1 unit of time, so we cannot destroy any bad luck at all, since both of the gems
 * take 0 seconds to give bad luck.
 *
 * Example 2:
 * A = [[ 0, 10 ], [ 1, 4 ], [ 1, 3 ], [ 2, 20 ]], output: 30. We can destroy 1st and 4th gem in 2 seconds, while receiving bad luck from 2nd and 3rd.
 */
public class Tests : BaseTest
{
    [Test]
    public void Test1()
    {
        var a = new[,]
        {
            { 0, 1 }, 
            { 0, 10 }
        };
        var expectedOutput = 0;
        
        // TODO
    }
    
    [Test]
    public void Test2()
    {
        var a = new[,]
        {
            { 0, 10 }, 
            { 1, 4 }, 
            { 1, 3 }, 
            { 2, 20 },
        };
        var expectedOutput = 30;
        
        // TODO
    }
}