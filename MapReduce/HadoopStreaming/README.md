# Hadoop streaming



Riferimenti utili

https://hadoop.apache.org/docs/stable/hadoop-streaming/HadoopStreaming.html

https://cwiki.apache.org/confluence/display/HADOOP2/HadoopStreaming


Per usare i programmi con Hadoop streaming pubblicare i progetti con target runtime `linux-x64`, e se il runtime .NET non è installato aggiungere l'opzione deployment mode `Self-contained`

Copiare sul cluster il file di input

```
hdfs dfs -put /local_file_name /remote_file_name
```

dopo aver avviato i servizi necessari con `start-dfs.sh` e `start-yarn.sh` eseguire

```shell
mapred streaming -input /input.txt -output /conteggio_parole -mapper ./Map -reducer ./Reduce -file ./Map -file ./Reduce
```





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

Output atteso

```
S1, 1
S2, 2
```



# Terzo esercizio

## Allarme temperatura cuscinetti per impianto



**Input**: file di testo contenente in ciascuna riga `impianto_id, sensore_id, timestamp, temperatura`

**Output**: per ogni impianto e sensore contare i giorni in cui la temperatura è stata sopra il valore di soglia di 50°C



Input

```
Z1, S1, 2021-01-01, 32
Z1, S2, 2021-01-01, 52
Z1, S3, 2021-01-01, 12
Z1, S1, 2021-01-02, 43
Z1, S2, 2021-01-02, 58
Z1, S3, 2021-01-02, 33
Z1, S1, 2021-01-03, 55
Z1, S2, 2021-01-03, 47
Z1, S3, 2021-01-03, 39
Z2, S1, 2021-01-01, 52
Z2, S2, 2021-01-01, 20
Z2, S3, 2021-01-01, 32
Z2, S1, 2021-01-02, 41
Z2, S2, 2021-01-02, 58
Z2, S3, 2021-01-02, 53
Z2, S1, 2021-01-03, 55
Z2, S1, 2021-01-03, 57
Z2, S3, 2021-01-03, 32
```

Output atteso

```
Z1 S2   2
Z1 S1   1
Z2 S1   3
Z2 S2   1
Z2 S3   1
```



# Quarto esercizio

## Allarme temperatura cuscinetti per impianto



**Input**: file di testo contenente in ciascuna riga `sensore_id, timestamp, temperatura`

**Output**: per ogni impianto e sensore elencare i giorni in cui la temperatura è stata sopra il valore di soglia di 50°C



Input

```
S1, 2021-01-01, 32
S2, 2021-01-01, 52
S1, 2021-01-02, 43
S2, 2021-01-02, 58
S1, 2021-01-03, 55
S1, 2021-01-03, 47
```

Output atteso

```
S2   2021-01-01, 2021-01-02
S1   2021-01-03
```

