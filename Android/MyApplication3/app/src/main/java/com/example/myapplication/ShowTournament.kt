package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.webkit.WebView

class ShowTournament : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_show_tournament)
        val webView: WebView = findViewById(R.id.webview)
        val kod = intent.getStringExtra("Kod")
        webView.getSettings().setJavaScriptEnabled(true)
        val url  = "http://10.0.2.2:3000/tournament-printer/#/${kod.toString()}"
        //Log.e("Kod", kod.toString())
        //Log.e("Url", url)
        webView.loadUrl(url)
    }

    fun come_back(view: View) {
        val intent = Intent(this, LoginOrRegister::class.java).apply {
        }
        startActivity(intent)
    }
}
