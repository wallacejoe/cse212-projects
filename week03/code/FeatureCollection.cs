class FeatureCollection {
    // Create a list of Earthquake data built from the provided
    // JSON. This list will be kept inside a separate Data
    // class which will then contain the Prop class. The Prop
    // class holds the actual property data.
    public Data[] Features { get; set; }
}

class Data {
    public Prop Properties { get; set; }
}

class Prop {
    public string Place { get; set; }
    public decimal Mag { get; set; }
}