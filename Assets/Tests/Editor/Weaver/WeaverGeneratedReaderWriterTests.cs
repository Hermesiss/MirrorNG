using NUnit.Framework;

namespace Mirror.Weaver.Tests
{
    public class WeaverGeneratedReaderWriterTests : WeaverTestsBuildFromTestName
    {
        [SetUp]
        public override void TestSetup()
        {
            WeaverAssembler.AddReferencesByAssemblyName(new string[] { "WeaverTestExtraAssembly.dll" });

            base.TestSetup();
        }

        [Test]
        public void CreatesForStructs()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForClass()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForClassInherited()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForClassWithValidConstructor()
        {
            IsSuccess();
        }

        [Test]
        public void GivesErrorForClassWithNoValidConstructor()
        {
            HasError("SomeOtherData can't be deserialized because it has no default constructor",
                "GeneratedReaderWriter.GivesErrorForClassWithNoValidConstructor.SomeOtherData");
        }

        [Test]
        public void CreatesForInheritedFromScriptableObject()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForStructFromDifferentAssemblies()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForClassFromDifferentAssemblies()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForClassFromDifferentAssembliesWithValidConstructor()
        {
            IsSuccess();
        }

        [Test]
        public void CanUseCustomReadWriteForTypesFromDifferentAssemblies()
        {
            IsSuccess();
        }

        [Test]
        public void GivesErrorWhenUsingUnityAsset()
        {
            HasError("Material can't be deserialized because it has no default constructor",
                "UnityEngine.Material");
        }

        [Test]
        public void GivesErrorWhenUsingObject()
        {
            // TODO: decide if we want to block sending of Object
            // would only want to be send as an arg as a base type for an Inherited object
            HasError("Cannot generate writer for Object. Use a supported type or provide a custom writer",
                "UnityEngine.Object");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for Object. Use a supported type or provide a custom reader",
            //    "UnityEngine.Object");
        }

        [Test]
        public void GivesErrorWhenUsingScriptableObject()
        {
            // TODO: decide if we want to block sending of ScripableObject
            // would only want to be send as an arg as a base type for an Inherited object
            HasError("Cannot generate writer for ScriptableObject. Use a supported type or provide a custom writer",
                "UnityEngine.ScriptableObject");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for ScriptableObject. Use a supported type or provide a custom reader",
            //    "UnityEngine.ScriptableObject");
        }

        [Test]
        public void GivesErrorWhenUsingMonoBehaviour()
        {
            HasError("Cannot generate writer for component type MonoBehaviour. Use a supported type or provide a custom writer",
                "UnityEngine.MonoBehaviour");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for component type MonoBehaviour. Use a supported type or provide a custom reader",
            //    "UnityEngine.MonoBehaviour");
        }

        [Test]
        public void GivesErrorWhenUsingTypeInheritedFromMonoBehaviour()
        {
            HasError("Cannot generate writer for component type MyBehaviour. Use a supported type or provide a custom writer",
                "GeneratedReaderWriter.GivesErrorWhenUsingTypeInheritedFromMonoBehaviour.MyBehaviour");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for component type MyBehaviour. Use a supported type or provide a custom reader",
            //    "GeneratedReaderWriter.GivesErrorWhenUsingTypeInheritedFromMonoBehaviour.MyBehaviour");
        }

        [Test]
        public void ExcludesNonSerializedFields()
        {
            // we test this by having a not allowed type in the class, but mark it with NonSerialized
            IsSuccess();
        }

        [Test]
        public void GivesErrorWhenUsingInterface()
        {
            HasError("Cannot generate writer for interface IData. Use a supported type or provide a custom writer",
                "GeneratedReaderWriter.GivesErrorWhenUsingInterface.IData");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for interface IData. Use a supported type or provide a custom reader",
            //    "GeneratedReaderWriter.GivesErrorWhenUsingInterface.IData");
        }

        [Test]
        public void CanUseCustomReadWriteForInterfaces()
        {
            IsSuccess();
        }

        [Test]
        public void GivesErrorWhenUsingAbstractClass()
        {
            HasError("Cannot generate writer for abstract class DataBase. Use a supported type or provide a custom writer",
                "GeneratedReaderWriter.GivesErrorWhenUsingAbstractClass.DataBase");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for abstract class DataBase. Use a supported type or provide a custom reader",
            //    "GeneratedReaderWriter.GivesErrorWhenUsingAbstractClass.DataBase");
        }

        [Test]
        public void CanUseCustomReadWriteForAbstractClass()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForEnums()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForArraySegment()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForStructArraySegment()
        {
            IsSuccess();
        }

        [Test]
        public void GivesErrorForJaggedArray()
        {
            HasError("Int32[][] is an unsupported type. Jagged and multidimensional arrays are not supported",
                "System.Int32[][]");
        }

        [Test]
        public void GivesErrorForMultidimensionalArray()
        {
            HasError("Int32[0...,0...] is an unsupported type. Jagged and multidimensional arrays are not supported",
                "System.Int32[0...,0...]");
        }

        [Test]
        public void GivesErrorForInvalidArrayType()
        {
            HasError("Cannot generate writer for Array because element MonoBehaviour does not have a writer. Use a supported type or provide a custom writer",
                "UnityEngine.MonoBehaviour[]");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for Array because element MonoBehaviour does not have a reader. Use a supported type or provide a custom reader",
            //    "UnityEngine.MonoBehaviour[]");
        }

        [Test]
        public void GivesErrorForInvalidArraySegmentType()
        {
            HasError("Cannot generate writer for ArraySegment because element MonoBehaviour does not have a writer. Use a supported type or provide a custom writer",
                "System.ArraySegment`1<UnityEngine.MonoBehaviour>");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for ArraySegment because element MonoBehaviour does not have a reader. Use a supported type or provide a custom reader",
            //    "System.ArraySegment`1<UnityEngine.MonoBehaviour>");
        }

        [Test]
        public void CreatesForList()
        {
            IsSuccess();
        }

        [Test]
        public void CreatesForStructList()
        {
            IsSuccess();
        }

        [Test]
        public void GivesErrorForInvalidListType()
        {
            HasError("Cannot generate writer for List because element MonoBehaviour does not have a writer. Use a supported type or provide a custom writer",
                "System.Collections.Generic.List`1<UnityEngine.MonoBehaviour>");
            // TODO change weaver to run checks for write/read at the same time
            //HasError("Cannot generate reader for List because element MonoBehaviour does not have a reader. Use a supported type or provide a custom reader",
            //    "System.Collections.Generic.List`1<UnityEngine.MonoBehaviour>");
        }
    }
}
