package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View

class ListOfTournaments : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_list_of_tournaments)
    }
    fun logout(view: View) {
        val intent = Intent(this, LoginOrRegister::class.java).apply {
        }
        startActivity(intent)
    }

    fun create_new_tournament(view: View) {
        val intent = Intent(this, CreateTournament::class.java).apply {
        }
        startActivity(intent)
    }
}