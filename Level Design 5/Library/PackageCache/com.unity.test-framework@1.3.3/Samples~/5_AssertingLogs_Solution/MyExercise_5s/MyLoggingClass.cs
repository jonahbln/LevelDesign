using UnityEngine;

namespace MyExercise_5s
{
    public class MyLoggingClass
    {
        public void DoSomething()
        {
            Debug.Log("Doing something");
        }
        
        public void DoSomethingElse()
        {
            Debug.LogError("An error happened. Code: " + Random.Range(0, 10));
        }
    }
}