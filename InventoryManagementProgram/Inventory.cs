/*
 *  Purpose: Properties of Rice, Pulses and wheats objects are stored.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   20-12-2019
 */

using System;
using System.Collections.Generic;

namespace ObjectOrientedProgram.InventoryManagementProgram
{
    class Inventory
    {

        public List<Properties> Rice { get; set; }
        public List<Properties> Pulses { get; set; }
        public List<Properties> Wheats { get; set; }


    }
}
