from pyspark import SparkConf, SparkContext
from pyspark.sql import SparkSession

conf = SparkConf()
conf.setMaster("local")
conf.setAppName("ITS Sample App")
#conf.set("spark.executor.memory", "1g")

sc = SparkContext(conf = conf)
spark = SparkSession.builder.getOrCreate()

# Configuration 
filename = "/home/its/sample_data/people.csv"

print("Reading file " + filename)
p = spark.read.options(header='True').csv(filename)

null = p.filter(p.Sesso.isNull())
f = p.filter(p.Sesso == "F")
m = p.filter(p.Sesso == "M")

print ('M:' + str(m.count()) + ' - F:' + str(f.count()) + ' - Null:' + str(null.count()) + ' -- SUM: ' + str(m.count()+f.count()+null.count()) )
print('Original dataset people count: ' + str(p.count()))

spark.stop()