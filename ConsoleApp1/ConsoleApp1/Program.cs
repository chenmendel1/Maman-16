using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project 
{
    class TreeNode
    {
        private int StudentID;
        private string name;
        private TreeNode left;
        private TreeNode right;
        private TreeNode parent;

        public TreeNode(int ID, string name)
        {
            this.StudentID = ID;
            this.name = name;
            this.left = this;
            this.right = this;
            this.parent = null;

        }
        
        public void Setleft(TreeNode node)
        {
            this.left = node;
        }

        public void Setparent(TreeNode node)
        {
            this.parent = node;
        }

        public void Setright(TreeNode node)
        {
            this.right = node;
        }
        public void Setname(string name)
        {
            this.name = name;
        }
        public void SetStudentID(int ID)
        {
            this.StudentID = ID;
        }

        public TreeNode Getleft()
        {
            return this.left;
        }

        public TreeNode Getright()
        {
            return this.right;
        }

        public TreeNode Getparent()
        {
            return this.parent;
        }
        public string Getname()
        {
            return this.name;
        }

        public int GetStudentID()
        {
            return this.StudentID;
        }

    }
    class BinaryNodeTree
    {
        private TreeNode root;
        private int SumOfNodes;
        private TreeNode median;

        public BinaryNodeTree(TreeNode root)
        {
            this.root = root;
            this.SumOfNodes = 0;
            this.median = root;
        }

        public TreeNode Min(TreeNode index)
        {
            while(index.Getleft().Getparent()==index)
            {
                index = index.Getleft();
            }
            return index;
        }

        public TreeNode Max(TreeNode index)
        {
            while (index.Getright().Getparent() == index)
            {
                index = index.Getright();
            }
            return index;
        }

        public TreeNode Successor(TreeNode index)
        {
            if (index.Getright().Getparent() == index)
                return Min(index.Getright());
            TreeNode parent = index.Getparent();
            while(parent!=null && index==parent.Getright())
            {
                index = parent;
                parent = parent.Getparent();
            }
            return parent;
        }
        public TreeNode Predecessor(TreeNode index)
        {
            if (index.Getleft().Getparent() == index)
                return Max(index.Getleft());
            TreeNode parent = index.Getparent();
            while (parent != null && index == parent.Getleft())
            {
                index = parent;
                parent = parent.Getparent();
            }
            return parent;
        }
        public TreeNode Search(TreeNode root,int key)
        {
            if (root == null || root.GetStudentID() == key)
                return root;
            else
                if (root.GetStudentID() < key)
                    if (root.Getleft().Getparent() == root)
                        Search(root.Getleft(),key);
                    else
                        return null;
                else
                    if (root.Getright().Getparent() == root)
                        Search(root.Getright(),key);
            return null;
        }
        public void Insert(TreeNode student)
        {
            bool state = true;
            if (this.SumOfNodes == 0)
            {
                this.SumOfNodes++;
                this.root = student;
                this.median = student;
            }
            else
            {
                TreeNode index = this.root;
                while (state)
                    if (index.GetStudentID() < student.GetStudentID())
                        if (index.Getright().Getparent() == index)
                            index = index.Getright();
                        else
                        {
                            state = false;
                            index.Setright(student);
                            student.Setparent(index);
                            student.Setright(Successor(student));
                            student.Setleft(Predecessor(student));
                            this.SumOfNodes++;
                        }
                    else
                        if (index.Getleft().Getparent() == index)
                        index = index.Getleft();
                    else
                    {
                        state = false;
                        index.Setleft(student);
                        student.Setparent(index);
                        student.Setright(Successor(student));
                        student.Setleft(Predecessor(student));
                        this.SumOfNodes++;
                    }
                if (student.GetStudentID() < this.median.GetStudentID())
                    if (SumOfNodes % 2 != 0)
                        this.median = Predecessor(this.median);
                if (student.GetStudentID() >= this.median.GetStudentID())
                    if (SumOfNodes % 2 == 0)
                        this.median = Successor(this.median);
            }
                
        }
        public void Delete(TreeNode student)
        {
            TreeNode x, y;
            if (student.GetStudentID() == this.median.GetStudentID())
                if (SumOfNodes % 2 == 0)
                    this.median = Successor(this.median);
                else
                    this.median = Predecessor(this.median);
            if (student.Getleft().Getparent() != student || student.Getright().Getparent() != student)
                y = student;
            else
                y = Successor(student);
            if (y.Getleft().Getparent() == y)
                x = y.Getleft();
            else
                x = y.Getright();
            if (x.Getparent() == y)
                x.Setparent(y.Getparent());
            if (y.Getparent() == null)
                this.root = x;
            else
                if (y == y.Getparent().Getleft())
                    y.Getparent().Setleft(x);
                else
                    y.Getparent().Setright(x);
            if (y != student)
            {
                student.Setname(y.Getname());
                student.SetStudentID(y.GetStudentID());
            }
               
            SumOfNodes--;
            if (y.GetStudentID() < this.median.GetStudentID())
                if (SumOfNodes % 2 == 0)
                    this.median = Successor(this.median);
            if (y.GetStudentID() > this.median.GetStudentID())
                if (SumOfNodes%2 != 0)
                    this.median = Predecessor(this.median);

        }
        }




            }
               

        


        








        static void Main(string[] args)
        {
        }
 