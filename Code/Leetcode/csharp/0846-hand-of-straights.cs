/*
https://leetcode.com/problems/hand-of-straights/submissions/1279993124/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
        {
            return false;
        }

        Dictionary<int, int> cardCount = new Dictionary<int, int>();
        foreach (int card in hand)
        {
            if (cardCount.ContainsKey(card))
            {
                cardCount[card]++;
            }
            else
            {
                cardCount[card] = 1;
            }
        }

        foreach (int card in hand)
        {
            int startCard = card;
            while (cardCount.ContainsKey(startCard - 1) && cardCount[startCard - 1] > 0)
            {
                startCard--;
            }

            while (startCard <= card)
            {
                while (cardCount.ContainsKey(startCard) && cardCount[startCard] > 0)
                {
  
                    for (int nextCard = startCard; nextCard < startCard + groupSize; nextCard++)
                    {
                        if (!cardCount.ContainsKey(nextCard) || cardCount[nextCard] == 0)
                        {
                            return false;
                        }
                        cardCount[nextCard]--;
                    }
                }
                startCard++;
            }
        }

        return true;
    }
}