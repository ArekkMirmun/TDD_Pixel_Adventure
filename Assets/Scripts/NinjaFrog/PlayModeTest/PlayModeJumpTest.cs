using System.Collections;
using NinjaFrog;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class NinjaFrogJumpTest
{
    private GameObject NinjaFrog;
    private GameObject Ground;

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene("SampleScene");
        Debug.Log("Scene Loaded");
    }
    [UnityTest]
    public IEnumerator NinjaFrogJump()
    {   
        yield return new WaitForSeconds(2);
        NinjaFrog = GameObject.Find("NinjaFrog");
        Ground = GameObject.Find("Ground");

        //Test if the NinjaFrog is grounded
        Assert.IsTrue(NinjaFrog.GetComponent<NinjaFrogMovement>().IsGrounded() == true, "NinjaFrog is not grounded.");
        
        NinjaFrog.GetComponent<NinjaFrogMovement>().Jump();
        yield return new WaitForSeconds(0.2f);
        //Test if the NinjaFrog is not grounded after jumping
        Assert.IsTrue(NinjaFrog.GetComponent<NinjaFrogMovement>().IsGrounded() == false, "NinjaFrog is not jumping.");
       
    }


    [TearDown]
    public void TearDown()
    {
        EditorSceneManager.UnloadSceneAsync("SampleScene");
    }
}
