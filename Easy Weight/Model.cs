using System;
using System.Collections;
using System.Collections.Generic;

namespace Easy_Weight{
    public class Model
    {
        /* 
         * For now, Entry will only contain weight. While a struct may
         * seem unnecessary at this point, it will come in handy in the
         * future if I want to implement certain features where it would
         * be useful to pair more data with each Entry. For example, a 
         * date object if I want to keep track of when entry's were made.
         */
        private struct Entry
        {
            public double weight;
        }

        /* 
         * A list to hold the past 3 months, a firstEntry var to keep,
         * and a list count because I only want to keep track of around
         * 3 months of entries. (90 days)
         */
        private List<Entry> entryList;
        private Entry firstEntry;
        private int listCount;

	    public Model()
	    {
            entryList = new List<Entry>();
            firstEntry = new Entry();
            listCount = 0;
	    }

        /*
         * Creates a new entry and adds it to the list. If the list is over
         * 90 entries, then the entry at the front of the list will be deleted.
         * If this is the first entry, then we set the first entry variable.
         */
        public void AddEntry(String weight)
        {
            /* Create the new entry and update listCount */
            Entry e = new Entry();
            e.weight = Convert.ToDouble(weight);
            entryList.Add(e);
            listCount++;

            /* Check for size */
            if (listCount > 90)
            {
                entryList.RemoveAt(0);
                listCount--;
            }

            /* Check for first entry */
            if (listCount == 1)
            {
                firstEntry = e;
            }
        }

        /* Makes a deep copy of entryList and returns it */
        private List<Entry> GetEntries()
        {
            List<Entry> returnList = new List<Entry>();
            for (int i = 0; i < listCount; i++){
                /* Create new entry and copy vars over */
                Entry e = new Entry();
                e.weight = entryList[i].weight;

                /* Add entry to the list */
                returnList.Add(e);
            }

            return returnList;
        }
    }
}
