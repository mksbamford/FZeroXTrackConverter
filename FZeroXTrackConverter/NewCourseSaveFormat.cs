using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FZeroX
{
    public class NewCourseSaveFormat
    {
        const int CRS_POINT_MAX = 64;

        public class EditPoint
        {
            Vector3 pos;
            short radiusL;
            short radiusR;
            uint type;

            public void Read(BigEndianBinaryReader br)
            {
                pos = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                radiusL = br.ReadInt16();
                radiusR = br.ReadInt16();
                type = br.ReadUInt32();
            }

            public void Write(BigEndianBinaryWriter bw)
            {
                bw.Write(pos.x);
                bw.Write(pos.y);
                bw.Write(pos.z);
                bw.Write(radiusL);
                bw.Write(radiusR);
                bw.Write(type);
            }

            public void Write(StreamWriter sw,
                short bank_angle,
                byte pit,
                byte dash,
                byte dart,
                byte slip,
                byte jump,
                byte jirai,
                byte gate,
                byte buil,
                byte kanban
            )
            {
                sw.Write("X = ");
                sw.WriteLine(pos.x * 0.1f);

                sw.Write("Y = ");
                sw.WriteLine(pos.y * 0.1f);

                sw.Write("Z = ");
                sw.WriteLine(pos.z * 0.1f);

                sw.Write("LeftWidth = ");
                sw.WriteLine(((float)radiusL) * 0.1f);

                sw.Write("RightWidth = ");
                sw.WriteLine(((float)radiusR) * 0.1f);

                sw.Write("Banking = ");
                sw.WriteLine(bank_angle);

                sw.Write("TrackType = ");
                sw.WriteLine(GetTrackType(type & TrackType.CRS_SHAPE_MASK));

                sw.Write("Texture = ");
                sw.WriteLine(type & TrackType.CRS_TEX_MASK);

                if (pit != byte.MaxValue)
                {
                    sw.Write("PitArea = ");//Pink Stuff
                    sw.WriteLine(pit);
                }

                if (dash != byte.MaxValue)
                {
                    sw.Write("DashPlate = ");//Boost
                    sw.WriteLine(dash);
                }

                if (dart != byte.MaxValue)
                {
                    sw.Write("DartZone = ");//Gravel?
                    sw.WriteLine(dart);
                }

                if (slip != byte.MaxValue)
                {
                    sw.Write("SlipZone = ");//Ice
                    sw.WriteLine(slip);
                }

                if (jump != byte.MaxValue)
                {
                    sw.Write("JumpPlate = ");//Jump bar
                    sw.WriteLine(jump);
                }

                if (jirai != byte.MaxValue)
                {
                    sw.Write("TrapField = ");//Mines
                    sw.WriteLine(jirai);
                }

                if (gate != byte.MaxValue)
                {
                    sw.Write("Gate = ");
                    sw.WriteLine(gate);
                }

                if (buil != byte.MaxValue)
                {
                    sw.Write("Structure = ");//Structure
                    sw.WriteLine(buil);
                }

                if (kanban != byte.MaxValue)
                {
                    sw.Write("Decoration = ");//Decoration
                    sw.WriteLine(kanban);
                }
            }

            private uint GetTrackType(uint value)
            {
                switch (value)
                {
                    case TrackType.CRS_SHAPE_ROAD: return 1; // Normal
                    case TrackType.CRS_SHAPE_HIROAD: return 2; // Highwall
                    case TrackType.CRS_SHAPE_TUBE: return 3; // Pipe
                    case TrackType.CRS_SHAPE_WIRE: return 4; // Cylinder
                    case TrackType.CRS_SHAPE_HALF: return 5;// Half-Pipe
                    case TrackType.CRS_SHAPE_TUNNEL: return 6; // Tunnel
                    case TrackType.CRS_SHAPE_AIR: return 0; // No Track
                    case TrackType.CRS_SHAPE_RIBBON: return 7; //No Wall
                    default:
                        throw new Exception("Unexpected Track Type: " + value);
        }
            }
        }

        byte version;
        byte controlPointCount;//pointNum
        byte venue;//haikei
        byte sky;

        uint checksum;

        byte run_ok_flag;
        byte[] name = new byte[23]; //hoge

        EditPoint[] controlPoints = new EditPoint[CRS_POINT_MAX];//point
        short[] bank_angle = new short[CRS_POINT_MAX];

        byte[] pit = new byte[CRS_POINT_MAX];
        byte[] dash = new byte[CRS_POINT_MAX];
        byte[] dart = new byte[CRS_POINT_MAX];
        byte[] slip = new byte[CRS_POINT_MAX];
        byte[] jump = new byte[CRS_POINT_MAX];
        byte[] jirai = new byte[CRS_POINT_MAX];
        byte[] gate = new byte[CRS_POINT_MAX];
        byte[] buil = new byte[CRS_POINT_MAX];
        byte[] kanban = new byte[CRS_POINT_MAX];

        public void Read(BigEndianBinaryReader br)
        {
            version = br.ReadByte();
            controlPointCount = br.ReadByte();
            venue = br.ReadByte();
            sky = br.ReadByte();

            checksum = br.ReadUInt32();

            run_ok_flag = br.ReadByte();
            name = br.ReadBytes(23);

            for(int i = 0; i < controlPoints.Length; i++)
            {
                var p = new EditPoint();
                p.Read(br);
                controlPoints[i] = p;
            }

            for (int i = 0; i < bank_angle.Length; i++)
                bank_angle[i] = br.ReadInt16();

            pit = br.ReadBytes(CRS_POINT_MAX);
            dash = br.ReadBytes(CRS_POINT_MAX);
            dart = br.ReadBytes(CRS_POINT_MAX);
            slip = br.ReadBytes(CRS_POINT_MAX);
            jump = br.ReadBytes(CRS_POINT_MAX);
            jirai = br.ReadBytes(CRS_POINT_MAX);
            gate = br.ReadBytes(CRS_POINT_MAX);
            buil = br.ReadBytes(CRS_POINT_MAX);
            kanban = br.ReadBytes(CRS_POINT_MAX);
        }

        public void Write(BigEndianBinaryWriter bw)
        {
            bw.Write(version);
            bw.Write(controlPointCount);
            bw.Write(venue);
            bw.Write(sky);
            bw.Write(checksum);
            bw.Write(run_ok_flag);
            bw.Write(name);
            foreach (var p in controlPoints)
                p.Write(bw);
            foreach (var x in bank_angle)
                bw.Write(x);
            bw.Write(pit);
            bw.Write(dash);
            bw.Write(dart);
            bw.Write(slip);
            bw.Write(jump);
            bw.Write(jirai);
            bw.Write(gate);
            bw.Write(buil);
            bw.Write(kanban);
        }

        public void Write(string source, StreamWriter sw)
        {
            sw.Write("Name = ");
            sw.WriteLine(Encoding.ASCII.GetChars(name));

            sw.WriteLine("Description = ");
            sw.WriteLine("JDescription = ");

            sw.Write("Source = ");
            sw.WriteLine(source);
            sw.WriteLine();
            
            sw.Write("Venue = ");
            sw.WriteLine(venue);

            sw.Write("Sky = ");
            sw.WriteLine(sky);

            //sw.Write("ROM_Music = ");
            //sw.WriteLine();

            //sw.Write("EK_Music = ");
            //sw.WriteLine();

            sw.Write("Horizon_Count = ");
            sw.WriteLine("0");

            sw.Write("CTL_Point_Count = ");
            sw.WriteLine(controlPointCount);

            sw.WriteLine();
            for (int i = 0; i < controlPointCount; i++)
            {
                sw.WriteLine("CTL_Point " + (i + 1));
                controlPoints[i].Write(sw,
                    bank_angle[i],
                    pit[i],
                    dash[i],
                    dart[i],
                    slip[i],
                    jump[i],
                    jirai[i],
                    gate[i],
                    buil[i],
                    kanban[i]);
                sw.WriteLine();
            }
        }
    }
}
