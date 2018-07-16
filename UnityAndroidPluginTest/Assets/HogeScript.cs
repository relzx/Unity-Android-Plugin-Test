using UnityEngine;
using UnityEngine.UI;

public class HogeScript: MonoBehaviour
{
    public Text m_text;

#if UNITY_ANDROID && !UNITY_EDITOR
    static string PLUGIN_PACKAGE_NAME = "com.relboxes.test.unityplugintestlibrary.Hoge";
#endif


    public void OnCallButtonA()
    {
        CallFuncA( "TEST A" );
        m_text.text = "Call CallFuncA.";
    }


    public void OnCallButtonB()
    {
        var modoriValue = CallFuncB( "TEST B" );
        m_text.text = "Call CallFuncB.\n" + modoriValue;
    }


    public void OnCallButtonC()
    {
        CallFuncC( "TEST C" );
        m_text.text = "Call CallFuncC.";
    }


    // NativeコードのFuncA 関数を呼び出す.
    // Native側のコードが引数を持たない関数なら、
    // andJavaObj.Call("FuncA"); のように引数を省略すればOK。
    void CallFuncA( string str )
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using ( var andJavaObj = new AndroidJavaObject( PLUGIN_PACKAGE_NAME ) )
        {
            andJavaObj.Call( "FuncA", str );
        }
#endif
    }


    // NativeコードのFuncB 関数を呼び出す.
    string CallFuncB( string str )
    {
        string modoriValue = "";
#if UNITY_ANDROID && !UNITY_EDITOR
        using ( var andJavaObj = new AndroidJavaObject( PLUGIN_PACKAGE_NAME ) )
        {
            modoriValue = andJavaObj.Call< string >( "FuncB", str );
        }
#endif
        return modoriValue;
    }


    // NativeコードのFuncC 関数を呼び出す.
    void CallFuncC(string str)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using ( var andJavaObj = new AndroidJavaObject( PLUGIN_PACKAGE_NAME ) )
        {
            andJavaObj.Call( "FuncC", gameObject.name, str );
        }
#endif
    }


    // ネイティブコードから呼ばれる関数
    public void onCallBack( string str )
    {
        Debug.Log("Call From Native. (" + str + ")");
    }

}