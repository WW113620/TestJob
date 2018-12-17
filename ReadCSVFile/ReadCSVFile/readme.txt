
使用说明：
      首先配置 App.config
      <add key="csvfile" value="G:\TestJob\CSVFile"/>  为csv 文件存放位置

	  <add key="printType" value="1"/>  方便计算 value=1时，计算的是LP 开头的数据，0或者默认计算TOU开头的数据

代码介绍
     项目中完全遵守面向对象结构，对公共方法进行了封装，逻辑清晰，可扩展性强
	 考虑数据量较大时，List<T>泛型集合容易浪费内存，所以使用了DataTable储存数据，排序都比较方便

