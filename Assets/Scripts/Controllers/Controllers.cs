﻿using System.Collections.Generic;
using UnityEngine;


namespace OMONGoose
{
    internal sealed class Controllers : IInitializable, IExecutable, ILateExecutable, ICleanable
    {
        private readonly List<IInitializable> _initializeControllers;
        private readonly List<IExecutable> _executeControllers;
        private readonly List<ILateExecutable> _lateControllers;
        private readonly List<ICleanable> _cleanupControllers;

        internal Controllers()
        {
            _initializeControllers = new List<IInitializable>();
            _executeControllers = new List<IExecutable>();
            _lateControllers = new List<ILateExecutable>();
            _cleanupControllers = new List<ICleanable>();
        }

        internal Controllers Add(IControllable controller)
        {
            if (controller is IInitializable initialize)
            {
                _initializeControllers.Add(initialize);
            }

            if (controller is IExecutable execute)
            {
                _executeControllers.Add(execute);
            }

            if (controller is ILateExecutable lateExecute)
            {
                _lateControllers.Add(lateExecute);
            }

            if (controller is ICleanable cleanup)
            {
                _cleanupControllers.Add(cleanup);
            }

            return this;
        }

        public void Initialization()
        {
            for (int i = 0; i < _initializeControllers.Count; i++)
            {
                _initializeControllers[i].Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executeControllers.Count; i++)
            {
                _executeControllers[i].Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        {
            for (int i = 0; i < _lateControllers.Count; i++)
            {
                _lateControllers[i].LateExecute(deltaTime);
            }
        }

        public void Cleanup()
        {
            for (int i = 0; i < _cleanupControllers.Count; i++)
            {
                _cleanupControllers[i].Cleanup();
            }
        }
    }
}