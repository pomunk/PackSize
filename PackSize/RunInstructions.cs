using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PackSize
{
    public class RunInstructions : IRunInstructions
    {
        private Coordinate _currentCoordinates;
        private List<Instruction> _instructionSet;

        public RunInstructions(string instructionSet)
        {
            _instructionSet = JsonConvert.DeserializeObject<List<Instruction>>(instructionSet);
        }

        public Coordinate CurrentCoordinates { get => _currentCoordinates; set => _currentCoordinates = value; }
        public List<Instruction> InstructionSet { get => _instructionSet; set => _instructionSet = value; }

        public void ProcessInstructions()
        {
            foreach(var instruction in InstructionSet)
            {
                
            }
        }
    }
}
