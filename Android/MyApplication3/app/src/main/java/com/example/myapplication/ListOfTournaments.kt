package com.example.myapplication

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.android.volley.AuthFailureError
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.Volley
import org.json.JSONArray


class ListOfTournaments : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        val token = intent.getStringExtra("Token")
        //Log.e("Token ListOfTournaments", token.toString())
        setContentView(R.layout.activity_list_of_tournaments)

        //Odczytuje z pamięci telefona z folderu Documents
        //val path_external = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOCUMENTS)
        //val path = File(path_external, "/"+"tournaments.json")
        //val jsonFileString = path.bufferedReader().use { it.readText() }

        val url = "http://jaqbklo.somee.com/api/tournament/tournamentsforuser"
        val queue = Volley.newRequestQueue(this)
        val request = object : JsonArrayRequest(
            Request.Method.GET,url,null,
            Response.Listener { response -> Log.e("Listner", response.toString())
                val items = JSONArray(response.toString())
                //Pobiera NAZWY i url TURNEJOW
                val itemsNames : MutableList<String> = mutableListOf()
                val itemsID : MutableList<String> = mutableListOf()
                for (elem in 0 until items.length()){
                    val itemName : String = items.getJSONObject(elem).getString("name")
                    itemsNames.add(itemName)
                    val itemId : String = items.getJSONObject(elem).getString("id")
                    itemsID.add(itemId)
                }

                val tournamentNames: List<String> = itemsNames
                val itemsIDlist: List<String> = itemsID
                //przekazywanie nazw i url do adaptera listy
                val adapter:ListOfTournamentsAdapter = ListOfTournamentsAdapter(tournamentNames, itemsIDlist, token.toString())
                val recycer: RecyclerView = findViewById(R.id.RecyclerView_id1)
                recycer.layoutManager = LinearLayoutManager(this)
                recycer.adapter = adapter},
            Response.ErrorListener { //error -> Log.e("errorListner", error.toString())
            }){
            @Throws(AuthFailureError::class)
            override fun getHeaders(): Map<String, String> {
                //przekazywanie tokenu
                val headers = HashMap<String, String>()
                headers.put("Content-Type", "application/json")
                val tokenCode = token.toString().substring(10, token.toString().length-2)
                headers.put("Authorization", "Bearer $tokenCode")
                return headers
            }
        }
        queue.add(request)
    }

   fun logout(view: View) {
       val intent = Intent(this, LoginOrRegister::class.java).apply {}
       startActivity(intent)
   }

   fun create_new_tournament(view: View) {
       val token = intent.getStringExtra("Token")
       //Log.e("Token", token.toString())
       val intent = Intent(this, CreateTournament::class.java).apply {}
       intent.putExtra("Token",token)
       startActivity(intent)
   }
}