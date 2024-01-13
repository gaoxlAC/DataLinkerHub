using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.Sjcj
{
    // 定义 BaseDataProtocol 类，继承自 Base，存放各种设备驱动协议
    [SugarTable("base_data_protocol")]
    public class BaseDataProtocol : Base
    {
        [SugarColumn(IsNullable = true, ColumnName = "protocol_id", ColumnDataType = "varchar", Length = 20)]
        public string ProtocolId { get; set; }  // 采集协议id

        [SugarColumn(IsNullable = true, ColumnName = "protocol_name", ColumnDataType = "varchar", Length = 50)]
        public string ProtocolName { get; set; }  // 采集协议名称，如Modbus RTU, OPC UA等

        [SugarColumn(IsNullable = true, ColumnName = "server_address", ColumnDataType = "varchar", Length = 200)]
        public string ServerAddress { get; set; }  // 服务器ip地址

        [SugarColumn(ColumnName = "server_port")]
        public int? ServerPort { get; set; }  // 服务器端口号

        [SugarColumn(IsNullable = true, ColumnName = "address", ColumnDataType = "varchar", Length = 100)]
        public string Address { get; set; }  // 通讯地址，OPC内的节点id，如：“n=2;s=通道1.设备1.测点1”

        [SugarColumn(IsNullable = true, ColumnName = "serial_port", ColumnDataType = "varchar", Length = 50)]
        public string SerialPort { get; set; }  // 串口号，Modbus需要用到

        [SugarColumn(ColumnName = "register_offset")]
        public int? RegisterOffset { get; set; }  // 寄存器地址偏移量，Modbus需要用到

        [SugarColumn(IsNullable = true, ColumnName = "remarks", ColumnDataType = "varchar", Length = 500)]
        public string Remarks { get; set; }  // 备注

        [SugarColumn(ColumnName = "del_flag")]
        public bool? DelFlag { get; set; }  // 逻辑删除字段，0-否，1-是
    }
}
