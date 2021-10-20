## A simple cache systems with Least Recently Used policy
The main purpose of a cache system is to provide faster access to data stored in cache with limited capacity. Therefore, we can summarize the basic requirements of a cache system as followings:

1.  When the max size of the cache is reached, remove the least recently used key.
2.  Whenever a key is fetched or updated, it becomes the most recently used.
3.  Both  `get`  and  `put`  operations complete in  [O(1) time complexity](https://stackoverflow.com/questions/697918/what-does-o1-access-time-mean)  (meaning that no matter how large the cache is, it takes the same amount of time to complete).
4.  When fetching a key that doesn’t exist, return a  `null`  value.
