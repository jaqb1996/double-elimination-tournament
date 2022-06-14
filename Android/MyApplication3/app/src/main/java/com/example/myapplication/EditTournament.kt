package com.example.myapplication

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import android.webkit.WebView
import androidx.appcompat.app.AppCompatActivity


class EditTournament : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        var token: String = intent.getStringExtra("Token").toString()
        //Log.e("Token EditTournament", token.substring(10, token.toString().length-2))
        setContentView(R.layout.activity_edit_tournament)
        var url: String = intent.getStringExtra("url").toString()
        val webView: WebView = findViewById(R.id.webview)
        val url_with_token = url + "?token="+ token.substring(10, token.toString().length-2)
        webView.getSettings().setJavaScriptEnabled(true)
        webView.loadUrl(url_with_token)
        //Log.e("url_with_token", url_with_token)
    }

    fun come_back(view: View) {
        val intent = Intent(this, ListOfTournaments::class.java).apply {
        }
        startActivity(intent)
    }
}