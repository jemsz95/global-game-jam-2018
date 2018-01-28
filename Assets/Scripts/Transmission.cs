using System;
using CustomLibrary;

[Serializable]
public class Transmission {
    int id;
    int room_id;
    bool finished = false;
    int node = 0;
    NodeType type = NodeType.Dialog;
}