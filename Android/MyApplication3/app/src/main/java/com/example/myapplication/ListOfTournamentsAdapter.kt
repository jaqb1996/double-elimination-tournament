package com.example.myapplication

import android.content.Intent
import android.os.Environment
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import org.json.JSONArray
import org.json.JSONException
import java.io.File
import java.io.FileWriter
import java.io.PrintWriter


class ListOfTournamentsAdapter(private val  tournamentsNames: List<String>, private val tournamentsId: List<String>, private val token: String) :
    RecyclerView.Adapter<ListOfTournamentsAdapter.ViewHolder>() {

    class ViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val textView: TextView
        val editBtn: Button
        val deleteBtn: Button
        init {
            textView = view.findViewById(R.id.tournament_textView)
            editBtn = view.findViewById(R.id.button10)
            deleteBtn = view.findViewById(R.id.button11)
        }
    }

    override fun onCreateViewHolder(viewGroup: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(viewGroup.context)
            .inflate(R.layout.item_of_tournament, viewGroup, false)
        return ViewHolder(view)
    }

    fun delete_tournament(view: View?, position: Int){
        //Potrzebne dla JSON
        //Odczytuje z pamięci telefona z folderu Documents
        val path_external = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOCUMENTS)
        val path = File(path_external, "/"+"tournaments.json")
        val jsonFileString = path.bufferedReader().use { it.readText() }
        val items = JSONArray(jsonFileString)

        //Usuwanie turnieja
        val output = JSONArray()
        val len: Int = items.length()
        for (i in 0 until len) {
            if (i != position) {
                try {
                    output.put(items.get(i))
                } catch (e: JSONException) {
                    throw RuntimeException(e)
                }
            }
        }

        //ZAPISUJE DO PAMIECI w TELEFONie odnowiony JSON
        try {
            PrintWriter(FileWriter(path))
                .use { it.write(output.toString()) }
        } catch (e: Exception) {
            e.printStackTrace()
        }
    }

    override fun onBindViewHolder(viewHolder: ViewHolder, position: Int) {
        viewHolder.textView.text = tournamentsNames[position]

        viewHolder.editBtn.setOnClickListener(object : View.OnClickListener {
            override fun onClick(view: View?) {
                val tournamentId: String = tournamentsId[position]
                val intent = Intent(view!!.context, EditTournament::class.java).apply { }
                val tournamentName: String = tournamentsNames[position]
               // val tournamentUrl_getJson = "http://jaqbklo.somee.com/api/tournament/get/$tournamentId"
                //val tournamentUrl_gobal  = "https://tournament-app.azurewebsites.net/#/$tournamentId"
                val tournamentUrl  = "http://10.0.2.2:3000/tournament-printer/#/$tournamentId"
                intent.putExtra("url", tournamentUrl);
                intent.putExtra("name", tournamentName);
                intent.putExtra("Token", token);
                view.context.startActivity(intent)
            }
        })

        viewHolder.deleteBtn.setOnClickListener(object : View.OnClickListener {
            override fun onClick(view: View?) {
                val intent = Intent(view!!.context, DeleteTournament::class.java).apply { }
                val tournamentsName: String = tournamentsNames[position]

                val id = tournamentsId[position]
                val tournamentsUrl = "http://jaqbklo.somee.com/api/tournament/delete/$id"
                intent.putExtra("url", tournamentsUrl);
                intent.putExtra("name", tournamentsName);
                intent.putExtra("Token", token);
                view.context.startActivity(intent)
            }
        })
    }
    override fun getItemCount() = tournamentsNames.size
}
