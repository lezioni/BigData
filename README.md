# MapReduce








# Primo esercizio

## Conteggio parole

**Input**: file di testo

**Output**: numero di occorrenze di ciascuna parola presente nel file



Input

```
Sopra la lama la barba canta
Sotto la lama la barba crepa
```

Output

```
Sopra, 1
La, 4
Lama, 2
Barba, 2
Canta, 1
Sotto, 1
Crepa, 1
```

Per usare i programmi con Hadoop streaming pubblicare i progetti con target runtime `linux-x64`, e se il runtime .NET non è installato aggiungere l'opzione deployment mode `Self-contained`

Copiare sul cluster il file di input

```
hdfs dfs -put /local_file_name /remote_file_name
```

dopo aver avviato i servizi necessari con `start-dfs.sh` e `start-yarn.sh` eseguire

```shell
mapred streaming -input /input.txt -output /conteggio_parole -mapper ./Map -reducer ./Reduce -file ./Map -file ./Reduce
```





# Secondo esercizio

## Allarme temperatura cuscinetti



**Input**: file di testo contenente in ciascuna riga `sensore_id, timestamp, temperatura`

**Output**: per ogni sensore contare i giorni in cui la temperatura è stata sopra il valore di soglia di 50°C



Input

```
S1, 2021-01-01, 32
S2, 2021-01-01, 52
S1, 2021-01-02, 43
S2, 2021-01-02, 58
S1, 2021-01-03, 55
S1, 2021-01-03, 47
```

Output

```
S1, 1
S2, 2
```

