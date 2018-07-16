package com.relboxes.test.unityplugintestlibrary

import com.unity3d.player.UnityPlayer;
import android.util.Log;

class Hoge {
    // Example 1: Unity側から渡された文字をログとして表示する関数
    fun FuncA(str: String)
    {
        Log.d("Unity Native", str);
    }

    // Example 2: Unity側から渡された文字をUnity側に返す関数
    fun FuncB(str: String):String
    {
        return "Back $str";
    }

    // Example 3: Unity側のスクリプトのonCallBack関数を呼び出す関数
    // スクリプトがアタッチされたGameObjectの名前を引数として渡し、
    // スクリプト内指定の関数を呼び出すことが可能。
    // 呼び出し先の関数がvoid型の場合は、
    // UnityPlayer.UnitySendMessage(gameObjName, "onCallBack", ""); のように記述する。
    // (3番目の引数は必ず記述しないとコンパイルエラーになるため)
    fun FuncC(gameObjName: String, str: String)
    {
        UnityPlayer.UnitySendMessage(gameObjName, "onCallBack", str);
    }
}