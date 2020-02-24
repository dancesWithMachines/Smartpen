package com.example.tilt;

import androidx.appcompat.app.AppCompatActivity;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.util.UUID;

public class MainActivity extends AppCompatActivity {
/*.s5SSSs.
      SS. .s5SSSSs. .s5SSSSs. .s5SSSs.  .s    s.  .s5SSSSs. s.  .s5SSSs.  .s    s.      .s5SSSSs. .s    s.  s.  .s5SSSs.      .s5SSSs.  .s5SSSs.  .s5SSSs.  .s5SSSs.      s.  .s5SSSs.      .s5SSSs.  .s    s.  .s5SSSs.  .s5SSSs.      .s5SSSs.  .s5SSSs.  .s    s.  .s5SSSs.  .s5SSSs.  .s5SSSs.      .s5 s.  .s5SSSs.  .s    s.      .s s.  s.  .s5SSSs.  .s5SSSSs. .s5SSSs.  .s    s.      .s5SSSs.  .s5SSSSs.     .s5 s.  .s5SSSs.  .s    s.  .s5SSSs.      .s5SSSs.  .s s.  s.  .s    s.      .s5SSSs.  s.  .s5SSSs.  .s    s.
sS    S%S    SSS       SSS          SS.       SS.    SSS    SS.       SS.       SS.        SSS          SS. SS.       SS.           SS.       SS.       SS.       SS.     SS.       SS.           SS.       SS.       SS.       SS.           SS.       SS.       SS.       SS.       SS.       SS.         SS.       SS.       SS.        SS. SS.       SS.    SSS          SS.       SS.           SS.    SSS            SS.       SS.       SS.       SS.           SS.    SS. SS.       SS.           SS. SS.       SS.       SS.
SS    S%S    S%S       S%S    sS    `:; sSs.  S%S    S%S    S%S sS    S%S sSs.  S%S        S%S    sS    S%S S%S sS    `:;     sS    `:; sS    S%S sS    S%S sS    `:;     S%S sS    `:;     sS    S%S sS    S%S sS    S%S sS    `:;     sS    `:; sS    S%S sSs.  S%S sS    `:; sS    `:; sS    S%S     ssS SSS sS    S%S sS    S%S     sS S%S S%S sS    S%S    S%S    sS    `:; sS    S%S     sS    S%S    S%S        ssS SSS sS    S%S sS    S%S sS    S%S     sS    S%S sS S%S S%S sSs.  S%S     sS    S%S S%S sS    `:; sS    S%S
SSSs. S%S    S%S       S%S    SSSs.     SS `S.S%S    S%S    S%S SS    S%S SS `S.S%S        S%S    SSSs. S%S S%S `:;;;;.       SS        SS    S%S SS    S%S SSSs.         S%S `:;;;;.       SS .sS::' SS    S%S SS .sS;:' SSSs.         SS        SSSs. S%S SS `S.S%S SS        SSSs.     SS .sS;:'      SSSSS  SS    S%S SS    S%S     SS S%S S%S SSSs. S%S    S%S    SS        SSSs. S%S     SSSs. S%S    S%S         SSSSS  SS    S%S SS    S%S SS .sS;:'     SS    S%S SS S%S S%S SS `S.S%S     SS .sS;:' S%S `:;;;;.   SSSSs.S:'
SS    S%S    S%S       S%S    SS        SS  `sS%S    S%S    S%S SS    S%S SS  `sS%S        S%S    SS    S%S S%S       ;;.     SS        SS    S%S SS    S%S SS            S%S       ;;.     SS        SS    S%S SS    ;,  SS            SS        SS    S%S SS  `sS%S SS        SS        SS    ;,        SSS   SS    S%S SS    S%S     SS S%S S%S SS    S%S    S%S    SS        SS    S%S     SS    S%S    S%S          SSS   SS    S%S SS    S%S SS    ;,      SS    S%S SS S%S S%S SS  `sS%S     SS    ;,  S%S       ;;. SS  "SS.
SS    `:;    `:;       `:;    SS        SS    `:;    `:;    `:; SS    `:; SS    `:;        `:;    SS    `:; `:;       `:;     SS        SS    `:; SS    `:; SS            `:;       `:;     SS        SS    `:; SS    `:; SS            SS        SS    `:; SS    `:; SS        SS        SS    `:;       `:;   SS    `:; SS    `:;     SS `:; `:; SS    `:;    `:;    SS        SS    `:;     SS    `:;    `:;          `:;   SS    `:; SS    `:; SS    `:;     SS    `:; SS `:; `:; SS    `:;     SS    `:; `:;       `:; SS    `:;
SS    ;,.    ;,.       ;,.    SS    ;,. SS    ;,.    ;,.    ;,. SS    ;,. SS    ;,.        ;,.    SS    ;,. ;,. .,;   ;,.     SS    ;,. SS    ;,. SS    ;,. SS    ;,.     ;,. .,;   ;,.     SS        SS    ;,. SS    ;,. SS    ;,.     SS    ;,. SS    ;,. SS    ;,. SS    ;,. SS    ;,. SS    ;,.       ;,.   SS    ;,. SS    ;,.     SS ;,. ;,. SS    ;,.    ;,.    SS    ;,. SS    ;,.     SS    ;,.    ;,.          ;,.   SS    ;,. SS    ;,. SS    ;,.     SS    ;,. SS ;,. ;,. SS    ;,.     SS    ;,. ;,. .,;   ;,. SS    ;,.
:;    ;:'    ;:'       ;:'    `:;;;;;:' :;    ;:'    ;:'    ;:' `:;;;;;:' :;    ;:'        ;:'    :;    ;:' ;:' `:;;;;;:'     `:;;;;;:' `:;;;;;:' ;;;;;;;:' `:;;;;;:'     ;:' `:;;;;;:'     `:        `:;;;;;:' `:    ;:' `:;;;;;:'     `:;;;;;:' :;    ;:' :;    ;:' `:;;;;;:' `:;;;;;:' `:    ;:'       ;:'   `:;;;;;:' `:;;;;;:'     `:;;:'`::' :;    ;:'    ;:'    `:;;;;;:' :;    ;:'     :;    ;:'    ;:'          ;:'   `:;;;;;:' `:;;;;;:' `:    ;:'     `:;;;;;:' `:;;:'`::' :;    ;:'     `:    ;:' ;:' `:;;;;;:' :;    ;:'


 */


    static final UUID mUUID = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB");

    BluetoothAdapter bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
    BluetoothDevice hc05 = bluetoothAdapter.getRemoteDevice("00:19:10:08:4C:2D");
    BluetoothSocket bluetoothSocket = null;

    OutputStream outputStream;
    InputStream inputStream;
    InputStreamReader inputStreamReader;

    boolean isConnected = false;
    String tekst ="";
    String bb="";

    TextView outputTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        System.out.println(bluetoothAdapter.getBondedDevices());

        int counter = 0;

        outputTextView = (TextView)findViewById(R.id.outputTextView);
        //Tworzenie socketu for communication

        do {
            try {
                bluetoothSocket = hc05.createInsecureRfcommSocketToServiceRecord(mUUID);
                System.out.println(bluetoothSocket);

                // Podłączanie do HC-05 (bo działa jako serwer (master))

                bluetoothSocket.connect();
                if (bluetoothSocket.isConnected())
                    isConnected = true;
                System.out.println(bluetoothSocket.isConnected());

                //Input stream
                inputStream = bluetoothSocket.getInputStream();
                inputStream.skip(inputStream.available());

                inputStreamReader = new InputStreamReader(inputStream);

                //bluetoothSocket.close();

            } catch (IOException e) {
                e.printStackTrace();
            }
            counter++;
        } while (!isConnected && counter < 20);
        if (isConnected) {
            ReadThread readThread = new ReadThread();
            readThread.start();
        }

    }

    public void disable(View view) {
        if (isConnected)
            try {
                outputStream = bluetoothSocket.getOutputStream();
                outputStream.write('d');
            } catch (IOException e) {
                e.printStackTrace();
            }
    }

    public void enable(View view) {
        if (isConnected)
            try {
                outputStream = bluetoothSocket.getOutputStream();
                outputStream.write('e');
            } catch (IOException e) {
                e.printStackTrace();
            }
    }

    class ReadThread extends Thread {
        @Override
        public void run() {
            if (isConnected){
                while (true) {
                    while (!tekst.endsWith("//")) {
                        try {
                            tekst += String.valueOf(Character.valueOf((char) inputStreamReader.read()));
                            if (!tekst.startsWith("X"))
                                tekst="";
                        } catch (IOException e) {
                            e.printStackTrace();
                        }
                    }
                    System.out.println(tekst);
                     bb = tekst;
                    outputTextView.post(new Runnable() {
                        public void run() {
                            outputTextView.setText(bb);
                        }
                    });
                    tekst="";
                }
            }
        }
    }
}
