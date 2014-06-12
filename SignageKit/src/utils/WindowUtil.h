//
//  WindowUtil.h
//  SignageKit
//
//  Created by Koki Ibukuro on 6/11/14.
//  Copyright (c) 2014 Koki Ibukuro. All rights reserved.
//

#import <Cocoa/Cocoa.h>

@interface WindowUtil : NSObject

+ (void) barShow:(bool)show;
+ (void) menuShow:(bool) show;
+ (void) setFrontScreen:(bool)isfront;

+ (unsigned long) screenCount;
+ (void) windowPosition:(NSRect) rect;
+ (void) fullAtScreen:(uint)index;
+ (void) fullAllScreen;

@end

