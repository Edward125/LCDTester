//
// File generated by HDevelop for HALCON/.NET (C#) Version 18.11.1.1
// Non-ASCII strings in this file are encoded in local-8-bit encoding (cp936).
// 
// Please note that non-ASCII characters in string constants are exported
// as octal codes in order to guarantee that the strings are correctly
// created on all systems, independent on any compiler settings.
// 
// Source files with different encoding should not be mixed in one project.
//
//  This file is intended to be used with the HDevelopTemplate or
//  HDevelopTemplateWPF projects located under %HALCONEXAMPLES%\c#

using System;
using HalconDotNet;

public partial class HDevelopExport
{
  public HTuple hv_ExpDefaultWinHandle;

  // Procedures 
  // External procedures 
  // Chapter: Develop
  // Short Description: Open a new graphics window that preserves the aspect ratio of the given image. 
  public void dev_open_window_fit_image (HObject ho_Image, HTuple hv_Row, HTuple hv_Column, 
      HTuple hv_WidthLimit, HTuple hv_HeightLimit, out HTuple hv_WindowHandle)
  {




    // Local iconic variables 

    // Local control variables 

    HTuple hv_MinWidth = new HTuple(), hv_MaxWidth = new HTuple();
    HTuple hv_MinHeight = new HTuple(), hv_MaxHeight = new HTuple();
    HTuple hv_ResizeFactor = new HTuple(), hv_ImageWidth = new HTuple();
    HTuple hv_ImageHeight = new HTuple(), hv_TempWidth = new HTuple();
    HTuple hv_TempHeight = new HTuple(), hv_WindowWidth = new HTuple();
    HTuple hv_WindowHeight = new HTuple();
    // Initialize local and output iconic variables 
    hv_WindowHandle = new HTuple();
    //This procedure opens a new graphics window and adjusts the size
    //such that it fits into the limits specified by WidthLimit
    //and HeightLimit, but also maintains the correct image aspect ratio.
    //
    //If it is impossible to match the minimum and maximum extent requirements
    //at the same time (f.e. if the image is very long but narrow),
    //the maximum value gets a higher priority,
    //
    //Parse input tuple WidthLimit
    if ((int)((new HTuple((new HTuple(hv_WidthLimit.TupleLength())).TupleEqual(0))).TupleOr(
        new HTuple(hv_WidthLimit.TupleLess(0)))) != 0)
    {
      hv_MinWidth.Dispose();
      hv_MinWidth = 500;
      hv_MaxWidth.Dispose();
      hv_MaxWidth = 800;
    }
    else if ((int)(new HTuple((new HTuple(hv_WidthLimit.TupleLength())).TupleEqual(
        1))) != 0)
    {
      hv_MinWidth.Dispose();
      hv_MinWidth = 0;
      hv_MaxWidth.Dispose();
      hv_MaxWidth = new HTuple(hv_WidthLimit);
    }
    else
    {
      hv_MinWidth.Dispose();
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      hv_MinWidth = hv_WidthLimit.TupleSelect(
          0);
      }
      hv_MaxWidth.Dispose();
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      hv_MaxWidth = hv_WidthLimit.TupleSelect(
          1);
      }
    }
    //Parse input tuple HeightLimit
    if ((int)((new HTuple((new HTuple(hv_HeightLimit.TupleLength())).TupleEqual(0))).TupleOr(
        new HTuple(hv_HeightLimit.TupleLess(0)))) != 0)
    {
      hv_MinHeight.Dispose();
      hv_MinHeight = 400;
      hv_MaxHeight.Dispose();
      hv_MaxHeight = 600;
    }
    else if ((int)(new HTuple((new HTuple(hv_HeightLimit.TupleLength())).TupleEqual(
        1))) != 0)
    {
      hv_MinHeight.Dispose();
      hv_MinHeight = 0;
      hv_MaxHeight.Dispose();
      hv_MaxHeight = new HTuple(hv_HeightLimit);
    }
    else
    {
      hv_MinHeight.Dispose();
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      hv_MinHeight = hv_HeightLimit.TupleSelect(
          0);
      }
      hv_MaxHeight.Dispose();
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      hv_MaxHeight = hv_HeightLimit.TupleSelect(
          1);
      }
    }
    //
    //Test, if window size has to be changed.
    hv_ResizeFactor.Dispose();
    hv_ResizeFactor = 1;
    hv_ImageWidth.Dispose();hv_ImageHeight.Dispose();
    HOperatorSet.GetImageSize(ho_Image, out hv_ImageWidth, out hv_ImageHeight);
    //First, expand window to the minimum extents (if necessary).
    if ((int)((new HTuple(hv_MinWidth.TupleGreater(hv_ImageWidth))).TupleOr(new HTuple(hv_MinHeight.TupleGreater(
        hv_ImageHeight)))) != 0)
    {
      hv_ResizeFactor.Dispose();
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      hv_ResizeFactor = (((((hv_MinWidth.TupleReal()
          )/hv_ImageWidth)).TupleConcat((hv_MinHeight.TupleReal())/hv_ImageHeight))).TupleMax()
          ;
      }
    }
    hv_TempWidth.Dispose();
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    hv_TempWidth = hv_ImageWidth*hv_ResizeFactor;
    }
    hv_TempHeight.Dispose();
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    hv_TempHeight = hv_ImageHeight*hv_ResizeFactor;
    }
    //Then, shrink window to maximum extents (if necessary).
    if ((int)((new HTuple(hv_MaxWidth.TupleLess(hv_TempWidth))).TupleOr(new HTuple(hv_MaxHeight.TupleLess(
        hv_TempHeight)))) != 0)
    {
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      {
      HTuple 
        ExpTmpLocalVar_ResizeFactor = hv_ResizeFactor*((((((hv_MaxWidth.TupleReal()
          )/hv_TempWidth)).TupleConcat((hv_MaxHeight.TupleReal())/hv_TempHeight))).TupleMin()
          );
      hv_ResizeFactor.Dispose();
      hv_ResizeFactor = ExpTmpLocalVar_ResizeFactor;
      }
      }
    }
    hv_WindowWidth.Dispose();
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    hv_WindowWidth = hv_ImageWidth*hv_ResizeFactor;
    }
    hv_WindowHeight.Dispose();
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    hv_WindowHeight = hv_ImageHeight*hv_ResizeFactor;
    }
    //Resize window
    //dev_open_window(...);
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    HOperatorSet.SetPart(hv_ExpDefaultWinHandle, 0, 0, hv_ImageHeight-1, hv_ImageWidth-1);
    }

    hv_MinWidth.Dispose();
    hv_MaxWidth.Dispose();
    hv_MinHeight.Dispose();
    hv_MaxHeight.Dispose();
    hv_ResizeFactor.Dispose();
    hv_ImageWidth.Dispose();
    hv_ImageHeight.Dispose();
    hv_TempWidth.Dispose();
    hv_TempHeight.Dispose();
    hv_WindowWidth.Dispose();
    hv_WindowHeight.Dispose();

    return;
  }

  // Chapter: Develop
  // Short Description: Switch dev_update_pc, dev_update_var and dev_update_window to 'off'. 
  public void dev_update_off ()
  {

    // Initialize local and output iconic variables 
    //This procedure sets different update settings to 'off'.
    //This is useful to get the best performance and reduce overhead.
    //
    // dev_update_pc(...); only in hdevelop
    // dev_update_var(...); only in hdevelop
    // dev_update_window(...); only in hdevelop


    return;
  }

  // Main procedure 
  private void action()
  {


    // Local iconic variables 

    HObject ho_Image, ho_ImageGray, ho_ImageMean;
    HObject ho_Region, ho_ImageRotate1, ho_Rectangle, ho_ImageReduced;
    HObject ho_ImagePart;

    // Local control variables 

    HTuple hv_WindowHandle = new HTuple(), hv_AbsoluteHisto = new HTuple();
    HTuple hv_RelativeHisto = new HTuple(), hv_MinThresh = new HTuple();
    HTuple hv_MaxThresh = new HTuple(), hv_Area = new HTuple();
    HTuple hv_Row = new HTuple(), hv_Column = new HTuple();
    HTuple hv_Phi3 = new HTuple(), hv_Row1 = new HTuple();
    HTuple hv_Column1 = new HTuple(), hv_Row2 = new HTuple();
    HTuple hv_Column2 = new HTuple();
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_Image);
    HOperatorSet.GenEmptyObj(out ho_ImageGray);
    HOperatorSet.GenEmptyObj(out ho_ImageMean);
    HOperatorSet.GenEmptyObj(out ho_Region);
    HOperatorSet.GenEmptyObj(out ho_ImageRotate1);
    HOperatorSet.GenEmptyObj(out ho_Rectangle);
    HOperatorSet.GenEmptyObj(out ho_ImageReduced);
    HOperatorSet.GenEmptyObj(out ho_ImagePart);
    dev_update_off();
    //dev_close_window(...);
    HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, "margin");
    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "blue");
    HOperatorSet.SetLineWidth(hv_ExpDefaultWinHandle, 3);
    //read_image (Image, 'D:/Work/LCD/LCD Pictures/昆山OK相片/1S20JES0YF07R90PMAL8_white.jpg')
    ho_Image.Dispose();
    HOperatorSet.ReadImage(out ho_Image, "E:/专案资料/LCD Pictures/昆山OK相片/LCD圖片/PASS/1S20FRA0H1IGR90P7YCW_white.jpg");
    hv_WindowHandle.Dispose();
    dev_open_window_fit_image(ho_Image, 0, 0, -1, -1, out hv_WindowHandle);
    HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
    ho_ImageGray.Dispose();
    HOperatorSet.Rgb3ToGray(ho_Image, ho_Image, ho_Image, out ho_ImageGray);
    ho_ImageMean.Dispose();
    HOperatorSet.MeanImage(ho_ImageGray, out ho_ImageMean, 9, 9);
    hv_AbsoluteHisto.Dispose();hv_RelativeHisto.Dispose();
    HOperatorSet.GrayHisto(ho_ImageMean, ho_ImageMean, out hv_AbsoluteHisto, out hv_RelativeHisto);
    hv_MinThresh.Dispose();hv_MaxThresh.Dispose();
    HOperatorSet.HistoToThresh(hv_RelativeHisto, 20, out hv_MinThresh, out hv_MaxThresh);
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    ho_Region.Dispose();
    HOperatorSet.Threshold(ho_ImageMean, out ho_Region, hv_MaxThresh.TupleSelect(
        0), hv_MaxThresh.TupleSelect(1));
    }
    hv_Area.Dispose();hv_Row.Dispose();hv_Column.Dispose();
    HOperatorSet.AreaCenter(ho_Region, out hv_Area, out hv_Row, out hv_Column);
    hv_Phi3.Dispose();
    HOperatorSet.OrientationRegion(ho_Region, out hv_Phi3);
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    ho_ImageRotate1.Dispose();
    HOperatorSet.RotateImage(ho_ImageMean, out ho_ImageRotate1, -(hv_Phi3.TupleDeg()
        ), "constant");
    }
    //count_obj (Region, Number)
    HOperatorSet.ClearWindow(hv_ExpDefaultWinHandle);
    //dev_display (Region)
    //dev_clear_obj (Region)
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    ho_Region.Dispose();
    HOperatorSet.Threshold(ho_ImageRotate1, out ho_Region, hv_MaxThresh.TupleSelect(
        0), hv_MaxThresh.TupleSelect(1));
    }
    hv_Row1.Dispose();hv_Column1.Dispose();hv_Row2.Dispose();hv_Column2.Dispose();
    HOperatorSet.InnerRectangle1(ho_Region, out hv_Row1, out hv_Column1, out hv_Row2, 
        out hv_Column2);
    ho_Rectangle.Dispose();
    HOperatorSet.GenRectangle1(out ho_Rectangle, hv_Row1, hv_Column1, hv_Row2, hv_Column2);
    ho_ImageReduced.Dispose();
    HOperatorSet.ReduceDomain(ho_ImageRotate1, ho_Rectangle, out ho_ImageReduced);
    ho_ImagePart.Dispose();
    HOperatorSet.CropDomain(ho_ImageReduced, out ho_ImagePart);
    HOperatorSet.DispObj(ho_ImagePart, hv_ExpDefaultWinHandle);
    HOperatorSet.WriteImage(ho_ImagePart, "bmp", 0, "C:/Users/Administrator/Desktop/test.bmp");



    ho_Image.Dispose();
    ho_ImageGray.Dispose();
    ho_ImageMean.Dispose();
    ho_Region.Dispose();
    ho_ImageRotate1.Dispose();
    ho_Rectangle.Dispose();
    ho_ImageReduced.Dispose();
    ho_ImagePart.Dispose();

    hv_WindowHandle.Dispose();
    hv_AbsoluteHisto.Dispose();
    hv_RelativeHisto.Dispose();
    hv_MinThresh.Dispose();
    hv_MaxThresh.Dispose();
    hv_Area.Dispose();
    hv_Row.Dispose();
    hv_Column.Dispose();
    hv_Phi3.Dispose();
    hv_Row1.Dispose();
    hv_Column1.Dispose();
    hv_Row2.Dispose();
    hv_Column2.Dispose();

  }

  public void InitHalcon()
  {
    // Default settings used in HDevelop
    HOperatorSet.SetSystem("width", 512);
    HOperatorSet.SetSystem("height", 512);
  }

  public void RunHalcon(HTuple Window)
  {
    hv_ExpDefaultWinHandle = Window;
    action();
  }

}

