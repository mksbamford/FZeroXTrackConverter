using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FZeroX
{
    class TrackType
    {
        /***********************************************
	        COURSE TEXTURE
        ***********************************************/
        public const uint ROAD_TYPES = 7;
        public const uint CRS_TEX_START_GRID = 0x00000000;
        public const uint CRS_TEX_START_CHECKER = 0x00000001;
        public const uint CRS_TEX_ROAD_01 = 0x00000002;
        public const uint CRS_TEX_ROAD_02 = 0x00000003;
        public const uint CRS_TEX_ROAD_03 = 0x00000004;
        public const uint CRS_TEX_ROAD_04 = 0x00000005;
        public const uint CRS_TEX_ROAD_05 = 0x00000006;

        public const uint HIROAD_TYPES = 3;
        public const uint CRS_TEX_HIROAD_01 = 0x00000000;
        public const uint CRS_TEX_HIROAD_02 = 0x00000001;
        public const uint CRS_TEX_HIROAD_03 = 0x00000002;

        public const uint TUBE_TYPES = 4;
        public const uint CRS_TEX_TUBE_01 = 0x00000000;
        public const uint CRS_TEX_TUBE_02 = 0x00000001;
        public const uint CRS_TEX_TUBE_03 = 0x00000002;
        public const uint CRS_TEX_TUBE_04 = 0x00000003;

        public const uint WIRE_TYPES = 4;
        public const uint CRS_TEX_WIRE_01 = 0x00000000;
        public const uint CRS_TEX_WIRE_02 = 0x00000001;
        public const uint CRS_TEX_WIRE_03 = 0x00000002;
        public const uint CRS_TEX_WIRE_04 = 0x00000003;

        public const uint HALF_TYPES = 4;
        public const uint CRS_TEX_HALF_01 = 0x00000000;
        public const uint CRS_TEX_HALF_02 = 0x00000001;
        public const uint CRS_TEX_HALF_03 = 0x00000002;
        public const uint CRS_TEX_HALF_04 = 0x00000003;

        public const uint TUNNEL_TYPES = 4;
        public const uint CRS_TEX_TUNNEL_01 = 0x00000000;
        public const uint CRS_TEX_TUNNEL_02 = 0x00000001;
        public const uint CRS_TEX_TUNNEL_03 = 0x00000002;
        public const uint CRS_TEX_TUNNEL_04 = 0x00000003;

        public const uint RIBBON_TYPES = 3;
        public const uint CRS_TEX_RIBBON_01 = 0x00000000;
        public const uint CRS_TEX_RIBBON_02 = 0x00000001;
        public const uint CRS_TEX_RIBBON_03 = 0x00000002;

        public const uint CRS_TEX_NONE = 0x0000003F;

        public const uint CRS_TEX_MASK = 0x0000003F;

        /***********************************************
            COURSE SHAPE
        ***********************************************/
        public const uint CRS_SHAPE_ROAD = 0x00000000;
        public const uint CRS_SHAPE_HIROAD = 0x00000040;
        public const uint CRS_SHAPE_TUBE = 0x00000080;
        public const uint CRS_SHAPE_WIRE = 0x000000C0;
        public const uint CRS_SHAPE_HALF = 0x00000100;
        public const uint CRS_SHAPE_TUNNEL = 0x00000140;
        public const uint CRS_SHAPE_AIR = 0x00000180;
        public const uint CRS_SHAPE_RIBBON = 0x000001C0;

        public const uint CRS_SHAPE_MASK = 0x000001C0;

        public const int CRS_SHAPE_SHIFT = 6;      /* No. = (X & MASK) >> SHIFT */

        /***********************************************
            COURSE JOINT
        ***********************************************/
        public const uint CRS_JOINT_1 = 0x00000200;
        public const uint CRS_JOINT_2 = 0x00000400;
        public const uint CRS_JOINT_MASK = 0x00000600;

        public const uint CRS_TRANSFORM_START_1 = 0x00000800;   /* for CrsVertex only */
        public const uint CRS_TRANSFORM_START_2 = 0x00001000;/* for CrsVertex only */
        public const uint CRS_TRANSFORM_START_MASK = 0x00001800;

        public const uint CRS_TRANSFORM_END_1 = 0x00002000; /* for CrsVertex only */
        public const uint CRS_TRANSFORM_END_2 = 0x00004000; /* for CrsVertex only */
        public const uint CRS_TRANSFORM_END_MASK = 0x00006000;

        /***********************************************
            COURSE FORM
        ***********************************************/
        public const uint CRS_FORM_ETC = 0x00000000;
        public const uint CRS_FORM_STRAIGHT = 0x00008000;
        public const uint CRS_FORM_CURVE_L = 0x00010000;
        public const uint CRS_FORM_CURVE_R = 0x00018000;
        public const uint CRS_FORM_S_L = 0x00020000;
        public const uint CRS_FORM_S_R = 0x00028000;

        public const uint CRS_FORM_MASK = 0x00038000;

        /***********************************************
            COURSE FLAGS
        ***********************************************/
        public const uint CRS_FLAG_AI_ROAD = 0x08000000;
        public const uint CRS_FLAG_JOINT_OK = 0x10000000;
        public const uint CRS_FLAG_INNER = 0x20000000;
        public const uint CRS_FLAG_CONTINUE = 0x40000000;
        public const uint CRS_FLAG_TPRESET = 0x80000000;	/* for CrsVertex only */

        /***********************************************
            COURSE TYPE
        ***********************************************/

        public const uint CRS_TYPE_START_GRID = (CRS_TEX_START_GRID | CRS_SHAPE_ROAD | CRS_FLAG_JOINT_OK | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_START_CHECKER = (CRS_TEX_START_CHECKER | CRS_SHAPE_ROAD | CRS_FLAG_JOINT_OK | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_ROAD_01 = (CRS_TEX_ROAD_01 | CRS_SHAPE_ROAD | CRS_FLAG_JOINT_OK | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_ROAD_02 = (CRS_TEX_ROAD_02 | CRS_SHAPE_ROAD | CRS_FLAG_JOINT_OK | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_ROAD_03 = (CRS_TEX_ROAD_03 | CRS_SHAPE_ROAD | CRS_FLAG_JOINT_OK | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_ROAD_04 = (CRS_TEX_ROAD_04 | CRS_SHAPE_ROAD | CRS_FLAG_JOINT_OK | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_ROAD_05 = (CRS_TEX_ROAD_05 | CRS_SHAPE_ROAD | CRS_FLAG_JOINT_OK | CRS_FLAG_AI_ROAD);

        public const uint CRS_TYPE_HIROAD_01 = (CRS_TEX_HIROAD_01 | CRS_SHAPE_HIROAD | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_HIROAD_02 = (CRS_TEX_HIROAD_02 | CRS_SHAPE_HIROAD | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_HIROAD_03 = (CRS_TEX_HIROAD_03 | CRS_SHAPE_HIROAD | CRS_FLAG_AI_ROAD);

        public const uint CRS_TYPE_TUBE_01 = (CRS_TEX_TUBE_01 | CRS_SHAPE_TUBE | CRS_FLAG_INNER);
        public const uint CRS_TYPE_TUBE_02 = (CRS_TEX_TUBE_02 | CRS_SHAPE_TUBE | CRS_FLAG_INNER);
        public const uint CRS_TYPE_TUBE_03 = (CRS_TEX_TUBE_03 | CRS_SHAPE_TUBE | CRS_FLAG_INNER);
        public const uint CRS_TYPE_TUBE_04 = (CRS_TEX_TUBE_04 | CRS_SHAPE_TUBE | CRS_FLAG_INNER);

        public const uint CRS_TYPE_WIRE_01 = (CRS_TEX_WIRE_01 | CRS_SHAPE_WIRE);
        public const uint CRS_TYPE_WIRE_02 = (CRS_TEX_WIRE_02 | CRS_SHAPE_WIRE);
        public const uint CRS_TYPE_WIRE_03 = (CRS_TEX_WIRE_03 | CRS_SHAPE_WIRE);
        public const uint CRS_TYPE_WIRE_04 = (CRS_TEX_WIRE_04 | CRS_SHAPE_WIRE);

        public const uint CRS_TYPE_HALF_01 = (CRS_TEX_HALF_01 | CRS_SHAPE_HALF);
        public const uint CRS_TYPE_HALF_02 = (CRS_TEX_HALF_02 | CRS_SHAPE_HALF);
        public const uint CRS_TYPE_HALF_03 = (CRS_TEX_HALF_03 | CRS_SHAPE_HALF);
        public const uint CRS_TYPE_HALF_04 = (CRS_TEX_HALF_04 | CRS_SHAPE_HALF);

        public const uint CRS_TYPE_TUNNEL_01 = (CRS_TEX_TUNNEL_01 | CRS_SHAPE_TUNNEL | CRS_FLAG_INNER | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_TUNNEL_02 = (CRS_TEX_TUNNEL_02 | CRS_SHAPE_TUNNEL | CRS_FLAG_INNER | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_TUNNEL_03 = (CRS_TEX_TUNNEL_03 | CRS_SHAPE_TUNNEL | CRS_FLAG_INNER | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_TUNNEL_04 = (CRS_TEX_TUNNEL_04 | CRS_SHAPE_TUNNEL | CRS_FLAG_INNER | CRS_FLAG_AI_ROAD);

        public const uint CRS_TYPE_AIR = (CRS_TEX_NONE | CRS_SHAPE_AIR | CRS_FLAG_JOINT_OK);

        public const uint CRS_TYPE_RIBBON_01 = (CRS_TEX_RIBBON_01 | CRS_SHAPE_RIBBON | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_RIBBON_02 = (CRS_TEX_RIBBON_02 | CRS_SHAPE_RIBBON | CRS_FLAG_AI_ROAD);
        public const uint CRS_TYPE_RIBBON_03 = (CRS_TEX_RIBBON_03 | CRS_SHAPE_RIBBON | CRS_FLAG_AI_ROAD);
    }
}